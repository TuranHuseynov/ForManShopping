$(".showclick").on("click", function () {
    var catid = $(this).attr("data-id");
    $.ajax({
        url: "/Home/ShowCat",
        data: { id: catid },
        method: "post",
        type: "JSON",
        success: function (response) {
            $(".productPartialResult").html(response);
        }
    })
})