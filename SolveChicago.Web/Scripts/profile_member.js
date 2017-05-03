﻿$(document).ready(function () {
    $('.addEntry').off('click').on('click', function (e) {
        var lastEntry = $(this).parent().children('div:last'),
            lastId = lastEntry.attr('data-id'),
            nextId = (parseInt(lastId) + 1).toString(),
            re1 = new RegExp("_" + lastId + "_", "g"),
            re2 = new RegExp("\\[" + lastId + "\\]", "g"),
            insertEntry = lastEntry.clone().html(function (i, oldHTML) { return oldHTML.replace(re1, "_" + nextId + "_").replace(re2, "[" + nextId + "]") }).attr('data-id', nextId);
        resetFormFields(insertEntry);
        lastEntry.after(insertEntry);
    });

    $('#Member_IsMilitary').on('change', function (e) {
        if ($(this).val().toLowerCase() == "true")
            $('#Member_MilitaryId').closest('.form-group').removeClass('hide');
        else
            $('#Member_MilitaryId').closest('.form-group').addClass('hide');
    });

    function resetFormFields($entry) {
        $entry.find('input').val('').attr('disabled', false);
        $entry.find('select').prop('selectedIndex', 0);
    }
});

window.bindAutocomplete = function ($element, list) {
    function split(val) {
        return val.split(/,\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }
    $element
        // don't navigate away from the field on tab when selecting an item
        .on("keydown", function (event) {
            if (event.keyCode === $.ui.keyCode.TAB &&
                $(this).autocomplete("instance").menu.active) {
                event.preventDefault();
            }
        })
        .autocomplete({
            minLength: 0,
            source: function (request, response) {
                // delegate back to autocomplete, but extract the last term
                response($.ui.autocomplete.filter(
                    list, extractLast(request.term)));
            },
            focus: function () {
                // prevent value inserted on focus
                return false;
            },
            select: function (event, ui) {
                var terms = split(this.value);
                // remove the current input
                terms.pop();
                // add the selected item
                terms.push(ui.item.value);
                // add placeholder to get the comma-and-space at the end
                terms.push("");
                this.value = terms.join(", ");
                return false;
            }
        });
}