$(function () {
    $("#uploadEditorImage").change(function () {
        var files = $("#uploadEditorImage").get(0).files;
        if (files.length === 0) {
            return;
        }
        var data = new FormData();
        data.append("itemId", $("#Id").val());
        data.append("HelpSectionImages", files[0]);
        var labelButton = $(this).parent();
        labelButton.addClass('disabled');
        $("#img-validation-error").text('');
        $(".esh-loader").removeClass("hidden");
        $.ajax({
            url: '/uploadimage',
            type: "POST",
            data: data,
            dataType: "json",
            processData: false,
            contentType: false,
            success: function (data) {
                $("#TempImageName").val(data.name);
                $(".esh-picture").attr("src", data.url);
                $(".esh-loader").addClass("hidden");
                labelButton.removeClass('disabled');
            },
            error: function (response, status, errorText) {
                $("#img-validation-error").text(errorText);
                $(".esh-loader").addClass("hidden");
                labelButton.removeClass('disabled');
            }
        });
    });
});