$(document).ready(function () {
    jQuery.ajaxSettings.traditional = true;

    function setupModalForAdding(options) {
        var dropdown = $('<select id="TypesSelect"></select>');
        for (var i = 0; i < options.length; i++) {
            var option = $('<option value="' + options[i] + '">' + options[i] + '</option>');

            dropdown.append(option);
        }

        $('#newGradeWeight').val(0);
        $('#Options').empty();
        $('#Options').append(dropdown);
        $('#currentRow').val(-1);
    }

    function setupModalForEdit(rowNumber, type, amount) {
        $('#Options').empty();

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
    }

    $('.removeRow').unbind('click').click(function () {
        removeRow(parseInt($(this).val()));
    });

    function removeRow(rowIndex) {
        $('tbody tr.' + rowIndex).remove();

        var remainingRows = $('tbody tr');

        remainingRows.each(function (index, element) {
            element.classList = '';
            element.classList = index;

            var buttons = element.lastElementChild.firstElementChild.children;

            for (var i = 0; i < buttons.length; i++) {
                buttons[i].value = index;
            }
        });
    }

    $('#submitModal').unbind('click').click(function () {
        var rowNumber = parseInt($('#currentRow').val());

        if (rowNumber < 0) {
            createRow();
        } else {
            updateRow(rowNumber);
        }

        $('#editModal').modal('hide');
    });

    $('#cancelModal').unbind('click').click(function () {
        $('#editModal').modal('hide');
    });
});