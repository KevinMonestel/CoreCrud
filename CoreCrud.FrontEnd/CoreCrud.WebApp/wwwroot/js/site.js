$(function () {
    $("*[remove-customer]").on("click", function (e) {
        e.preventDefault();

        response = confirm("Are you sure?");

        if (response) {
            let element = $(this);
            let id = element.data("id");
            let url = element.data("url");

            $.post(url, { id }, function (response) {
                if (response.result) {
                    window.location.reload();
                    return;
                }
                alert("Failed");
            }).fail(function (state) {
                alert("Failed");
            });
        }
    });
});