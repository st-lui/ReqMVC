$(document).ready(function () {
    $.validator.addMethod("date", function (value) {
        var date = Date.parseExact(value,"dd.MM.yyyy H:m:s");
        if (date == null)
            return false;
        return true;
    });
});