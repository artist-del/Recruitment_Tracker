{
    $('#btnSave').click(() => {
        let url = '/Home/SaveInfo';
        let data = $('#formSave').serialize();
        let formArray = data.split('&');

        let hasEmptyField = false;
        for (let i = 0; i < formArray.length; i++) {
            let pair = formArray[i].split('=');
            if (pair[1] === "") {
                hasEmptyField = true;
                break;
            }
        }

        if (hasEmptyField) {
            Swal.fire("Warning", "Please fill in all required fields!", "warning");
        }
        else {
            $.ajax({
                url: url,
                type: 'post',
                data: data,
                success: (e) => {
                    if (e.msg == true) {
                        Swal.fire(
                            "Success", "success", "success"
                        ).then(() => {
                            window.location.href = "/Home/Index";
                        })

                    }
                }
            })
        }
    })

}