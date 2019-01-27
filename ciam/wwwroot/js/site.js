// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function DisplayErrors(formId, errors) {
    var $ul = $('#' + formId).find(".validation-summary-errors ul");

    if ($ul.length === 0)
        $ul = $('#' + formId).find(".validation-summary-valid ul");

    $ul.empty();
    $('#' + formId + ' [data-valmsg-for]').text("");

    for (var i = 0; i < errors.length; i++) {
        if (errors[i].Key === "") { 
            $.each(errors[i].Value, function (index, value) {
                $ul.append("<li>" + value + "</li>");
            });
        } else {
            $('#' + formId + ' [data-valmsg-for="' + errors[i].Key + '"]').text(errors[i].Value[0]);
        }
    }
}