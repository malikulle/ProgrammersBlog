$(document).ready(function () {
    console.log("ready")
    $(function () {
        $(document).on("click", "#btnSave", function (event) {
            event.preventDefault();
            const form = $("#form-comment-add");
            const actionUrl = form.attr("action");
            console.log(actionUrl)
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function (data) {
                const commentAddAjaxModel = jQuery.parseJSON(data);
                console.log(commentAddAjaxModel);
                const newFormBody = $(".form-card", commentAddAjaxModel.CommentAddPartial);
                const cardBody = $(".form-card");
                cardBody.replaceWith(newFormBody);
                const isValid = newFormBody.find("[name='IsValid']").val() === "True";
                if (isValid) {
                    const singleComment = `
                    <div class="media mb-4">
                        <img class="d-flex mr-3 rounded-circle" src="http://placehold.it/50x50" alt="">
                        <div class="media-body">
                            <h5 class="mt-0">${commentAddAjaxModel.CommentDto.Comment.CreatedByName}</h5>
                            ${commentAddAjaxModel.CommentDto.Comment.Text}
                        </div>
                    </div>
                        `;
                    const newSingleCommentObject = $(singleComment);
                    newSingleCommentObject.hide();
                    $("#comments").append(newSingleCommentObject)
                    newSingleCommentObject.fadeIn(3000);
                    toastr.success("Yorum Başarılı Bir Şekilde Eklendi. Onaylanana kadar bekleyiniz.");
                    $("#btnSave").prop("disabled", true);
                    setTimeout(() => {
                        $("#btnSave").prop("disabled", false);
                    }, 15000)
                } else {
                    var summaryText = "";
                    $('#validation-summary > ul > li').each(function () {
                        var text = $(this).text();
                        summaryText += `*${text}\n`;
                    });
                    toastr.warning(summaryText);
                }
            });
        });
    });

});