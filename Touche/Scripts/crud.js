$(document).ready(function () {
    $(".delete-item").click(function (e) {
        controller = $(this).data('controller');
        id = $(this).data('id');
        button = $(this);
        bootbox.confirm({
            message: "This is a confirm with custom button text and color! Do you like it?",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                $.ajax({
                    url: '/' + controller + '/delete/' + id,
                    method: "DELETE",
                    success: function () {
                        button.parent().parent().remove();
                    },
                    error: function (data) {
                        console.log(data);
                        bootbox.alert("Error!");
                    }
                })
            }
        });
    })

})