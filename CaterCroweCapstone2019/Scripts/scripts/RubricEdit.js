$(document).ready(function () {
    jQuery.ajaxSettings.traditional = true;
    var errorText = '';
    var warningText = '';

    function setupModal() {
        $("#Options select").attr('tabindex', 1);
        $('#newGradeWeight').attr('tabindex', 2);
        $('.modal-body div button').eq(0).attr('tabindex', 3);
        $('.modal-body div button').eq(1).attr('tabindex', 4);
    }

    function unFoucusModal() {
        $("#Options select").attr('tabindex', -1);
        $('#newGradeWeight').attr('tabindex', -1);
        $('.modal-body div button').eq(0).attr('tabindex', -1);
        $('.modal-body div button').eq(1).attr('tabindex', -1);
    }

    function setupModalForAdding(options) {
        var dropdown = $('<select id="TypesSelect"></select>');
        for (var i = 0; i < options.length; i++) {
            var option = $('<option value="' + options[i] + '">' + options[i] + '</option>');

            dropdown.append(option);
        }

        $("#newTypeContainer").css('display', 'block');

        $('#newGradeWeight').val(0);
        $('#Options').empty();
        $('#Options').append(dropdown);
        $('#currentRow').val(-1);

        setupModal();
    }

    function setupModalForEdit(rowNumber, type, amount) {
        $('#Options').empty();

        $("#newTypeContainer").css('display', 'none');

        var text = $('<p></p>');
        text.text(type);

        $('#Options').append(text);

        $('#newGradeWeight').val(amount);
        $('#currentRow').val(rowNumber);
    }

    function updateRow(rowNumber) {
        var row = $('tr.' + rowNumber);
        var newValue = parseInt($('#newGradeWeight').val());

        row.find('.weightValue p').text(newValue);
        row.find('.weightValue input').val(newValue);
    }

    function createRow() {
        var rowCount = $('tbody').children().length;
        var row = $('<tr class="' + rowCount + '"></tr>');

        var type = $('#TypesSelect').val();

        if ($('#createNew').is(':checked')) {
            type = $('#NewType').val();
            addWeightType(type);
        }

        var amount = parseInt($('#newGradeWeight').val());

        var typeCol = $('<td class="type"><p>' + type + '</p></td>');
        var amountCol = $('<td class="weightValue"><p>' + amount + '</p><input name="RubricValues[' + type + ']" value="' + amount + '" hidden/></td>');

        row.append(typeCol);
        row.append(amountCol);

        var editButton = $('<button type="button" class="btn btn-primary editRow" value="' + rowCount + '">Edit</button>')
            .unbind('click')
            .click(function () { editRow($(this)) });
        var removeButton = $('<button type="button" class="btn btn-secondary removeRow" value="' + rowCount + '">Remove</button>')
            .unbind('click')
            .click(function () { removeRow(parseInt($(this).val())) });

        var buttonGroup = $('<div class="btn-group"></div>');
        buttonGroup.append(editButton);
        buttonGroup.append(removeButton);

        var buttonCol = $('<td></td>').append(buttonGroup);

        row.append(buttonCol);

        $('tbody').append(row);
    }

    $('#createNew').unbind('change').change(function () {
        showNewType($(this).is(':checked'));
    });

    function showNewType(show) {
        if (show) {
            $("#Options").css('display', 'none');
            $('#NewType').removeAttr('hidden');
        } else {
            $("#Options").css('display', 'block');
            $('#NewType').attr('hidden', 'hidden');
        }
    }

    $("#addRowButton").unbind('click').on('click', function () {
        var _usedTypes = new Array();
        var htmlValues = $('.type p');

        for (var i = 0; i < htmlValues.length; i++) {
            var currentVal = htmlValues.eq(i).text();
            _usedTypes.push(currentVal);
        }

        $.get('/Course/GetRubricTypes',
            {
                usedTypes: _usedTypes
            },
            function (response) {
            setupModalForAdding(response);
            $('#editModal').modal('show');
        });
    });

    $('.editRow').unbind('click').click(function () {
        editRow($(this));
    });

    function editRow(buttonCall) {
        var rowNumber = parseInt(buttonCall.val());
        var type = buttonCall.parent().parent().parent().find('.type').text();
        var amount = parseFloat(buttonCall.parent().parent().parent().find('.weightValue').text());

        setupModalForEdit(rowNumber, type, amount);
        $('#editModal').modal('show');

        setupModal();
    }

    $('.removeRow').unbind('click').click(function () {
        removeRow(parseInt($(this).val()));
    });

    function removeRow(rowIndex) {
        warningText = '';
        $('tbody tr.' + rowIndex).remove();

        var remainingRows = $('tbody tr');

        var remainingPercent = 0;

        remainingRows.each(function (index, element) {
            element.classList = '';
            element.classList = index;

            var buttons = element.lastElementChild.firstElementChild.children;

            remainingPercent += parseInt(element.children[1].children[1].value);

            for (var i = 0; i < buttons.length; i++) {
                buttons[i].value = index;
            }
        });

        if (remainingPercent > 100) {
            warningText = 'Warning: Percent is over 100.'
        }

        $('.warning-text').text(warningText);
    }

    $('#submitModal').unbind('click').click(function (event) {
        event.preventDefault();
        var rowNumber = parseInt($('#currentRow').val());
        errorText = "";
        warningText = '';

        var isValid = (rowNumber < 0 && ValidateCreateInput()) || (rowNumber >= 0 && ValidateEditInput());

        if (isValid) {
            if (rowNumber < 0) {
                createRow();
            } else {
                updateRow(rowNumber);
            }

            $('#editModal').modal('hide');
            unFoucusModal();
        }

        $('.warning-text').text(warningText);
        $("#modalError").text(errorText);
    });

    $('#cancelModal').unbind('click').click(function () {
        $('#editModal').modal('hide');
        unFoucusModal();
    });

    function ValidateCreateInput() {
        var validText = $('Options input').val() !== '';

        if (!validText) {
            errorText += 'Rubric type not accepted, try a different one. ';
        }

        var typeExisits = typeAlreadyExisits($('#NewType').val());

        if (typeExisits) {
            errorText += 'Type already exsists. ';
        }

        var total = calculateTotal();
        var overPercent = total > 100;
        var underPercent = total < 100;

        if (overPercent) {
            warningText += 'Warning: The overall percent is over 100. ';
        }

        if (underPercent) {
            warningText += 'Warning: The overall percent is under 100.';
        }

        var isNegative = $('#newGradeWeight').val() < 1;

        if (isNegative) {
            errorText += 'The weight must be at least 1';
        }

        return validText && !typeExisits && !isNegative;
    }

    function ValidateEditInput() {
        var total = calculateTotal();

        var overPercent = total > 100;
        var underPercent = total < 100;

        if (overPercent) {
            warningText += 'Warning: The overall percent is over 100. ';
        }

        if (underPercent) {
            warningText += 'Warning: The overall percent is under 100.';
        }

        var isNegative = $('#newGradeWeight').val() < 1;

        if (isNegative) {
            errorText += 'The weight must be at least 1 ';
        }

        return !isNegative;
    }

    function typeAlreadyExisits(type) {
        var usedTypes = $('tbody tr td.type p');
        var unusedTypes = $('#Options select option');

        for (var count = 0; count < usedTypes.length; count++) {
            var currentType = usedTypes.eq(count).text();

            if (currentType === type) {
                return true;
            }
        }

        for (var count = 0; count < unusedTypes.length; count++) {
            var currentType = unusedTypes.eq(count).val();

            if (currentType === type) {
                return true;
            }
        }

        return false;
    }

    function calculateTotal() {
        var values = $('.weightValue input');

        var total = parseFloat($("#newGradeWeight").val());

        for (var i = 0; i < values.length; i++) {
            total += parseFloat(values.eq(i).val());
        }

        return total;
    }

    $('#submit').click(function (event) {
        if (ValidateInput()) {
            event.preventDefault();
            $('.error').text(errorText);
        } else {
            $('.error').text('');
        }
    });

    function addWeightType(_type) {
        $.post('/Teacher/AddRubricType',
            {
                type: _type
            },
            function () {

            }
        )
    }
});