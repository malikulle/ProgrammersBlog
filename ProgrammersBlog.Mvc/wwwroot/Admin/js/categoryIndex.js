$(document).ready(function () {
    $('#categoriesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Ekle',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {

                }
            }
        ],
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        }
    });
    $(function () {
        var url = 'Categories/Add';
        var placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                var form = $('#form-category-add');
                var actionUrl = form.attr('action');
                var dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    console.log(data);
                    var categoryAddAjaxModel = jQuery.parseJSON(data);
                    console.log(categoryAddAjaxModel);
                    var newFormBody = $('.modal-body', categoryAddAjaxModel.CategoryAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    var isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        var newTableRow = `
                                <tr name='${categoryAddAjaxModel.CategoryDto.Category.Id}'>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Id}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Name}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Description}</td>
                                                    <td>${convertFirtLetterToUpperCase(categoryAddAjaxModel.CategoryDto.Category.IsActive.toString())}</td>
                                                    <td>${convertFirtLetterToUpperCase(categoryAddAjaxModel.CategoryDto.Category.IsDeleted.toString())}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.Note}</td>
                                                    <td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.CreatedDate)}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.CreatedByName}</td>
                                                    <td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.ModifiedDate)}</td>
                                                    <td>${categoryAddAjaxModel.CategoryDto.Category.ModifiedByName}</td>
                                                    <td>
                                                        <button class="btn btn-primary btn-sm"><span class="fas fa-edit"></span>Düzenle</button>
                                                        <button class="btn btn-danger btn-sm btnDelete"  data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-minus-circle"></span>Sil</button>
                                                    </td>
                                                </tr>`;
                        var newTableRowObject = $(newTableRow);
                        newTableRowObject.hide();
                        $('#categoriesTable').append(newTableRowObject);
                        newTableRowObject.fadeIn(3500);
                        toastr.success(`${categoryAddAjaxModel.CategoryDto.Message}`, 'Başarılı İşlem!');
                    } else {
                        var summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            var text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                });
            });
    });
    $(document).on("click",
        ".btnDelete",
        function (event) {
            event.preventDefault();
            var id = $(this).attr("data-id");
            Swal.fire({
                title: 'Silmek İstediğinize Emin misiniz ?',
                text: "Seçili Kategori Silinecektir.",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet,Silmek istiyorum.!',
                cancelButtonText: "Hayır, Silmek istemiyorum.!"
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: "DELETE",
                        dataType: "json",
                        data: { categoryId: id },
                        url: 'Categories/DeleteCategories',
                        success: function () {
                            Swal.fire(
                                'Silindi!',
                                'Kategori Başarılı Bir Şekilde Silindi.',
                                'success'
                            );
                            var tableRow = $(`[name="${id}"]`);
                            tableRow.fadeOut(3500);
                        },
                        error: function (err) {
                            console.log(err);
                        }
                    });

                }
            });
        });

    $(function () {
        var url = "Categories/Update";
        var placeHolderDiv = $('#modalPlaceHolder');
        $(document).on("click",
            ".btnUpdate",
            function (event) {
                event.preventDefault();
                var id = $(this).attr("data-id");
                $.get(url, { categoryId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find(".modal").modal("show");
                }).fail(function () {
                    toastr.error("Bir Hata Oluştu");
                });
            });


        placeHolderDiv.on("click",
            "#btnUpdate",
            function (event) {
                event.preventDefault();

                var form = $("#form-category-update");
                var actionUrl = form.attr("action");
                var dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    var categoryUpdateAjaxModel = jQuery.parseJSON(data);
                    console.log(categoryUpdateAjaxModel);
                    var newFormBody = $(".modal-body", categoryUpdateAjaxModel.CategoryUpdatePartial);
                    placeHolderDiv.find(".modal-body").replaceWith(newFormBody);
                    var isValid = newFormBody.find('[name="IsValid"]').val() === "True";
                    if (isValid) {
                        placeHolderDiv.find(".modal").modal("hide");

                        var newTableRow = `
                                <tr name='${categoryUpdateAjaxModel.CategoryDto.Category.Id}'>
                                                    <td>${categoryUpdateAjaxModel.CategoryDto.Category.Id}</td>
                                                    <td>${categoryUpdateAjaxModel.CategoryDto.Category.Name}</td>
                                                    <td>${categoryUpdateAjaxModel.CategoryDto.Category
                            .Description}</td>
                                                    <td>${convertFirtLetterToUpperCase(categoryUpdateAjaxModel
                                .CategoryDto.Category.IsActive.toString())}</td>
                                                    <td>${convertFirtLetterToUpperCase(categoryUpdateAjaxModel
                                .CategoryDto.Category.IsDeleted.toString())}</td>
                                                    <td>${categoryUpdateAjaxModel.CategoryDto.Category.Note}</td>
                                                    <td>${convertToShortDate(categoryUpdateAjaxModel.CategoryDto
                                .Category.CreatedDate)}</td>
                                                    <td>${categoryUpdateAjaxModel.CategoryDto.Category
                            .CreatedByName}</td>
                                                    <td>${convertToShortDate(categoryUpdateAjaxModel.CategoryDto
                                .Category.ModifiedDate)}</td>
                                                    <td>${categoryUpdateAjaxModel.CategoryDto.Category
                            .ModifiedByName}</td>
                                                    <td>
                                                        <button class="btn btn-primary btn-sm btnUpdate" data-id=${categoryUpdateAjaxModel.CategoryDto.Category.Id}><span class="fas fa-edit"></span>Düzenle</button>
                                                        <button class="btn btn-danger btn-sm btnDelete"  data-id="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"><span class="fas fa-minus-circle"></span>Sil</button>
                                                    </td>
                                                </tr>`;
                        var newTableRowObject = $(newTableRow);
                        var categoryTableRow = $(`[name="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"]`);
                        categoryTableRow.hide();
                        categoryTableRow.replaceWith(newTableRowObject);
                        categoryTableRow.fadeIn(3500);
                        toastr.success("Kategori Başarılı Bir Şekilde Güncellenmiştir");
                    } else {
                        var summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            var text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                }).fail(function(res) {
                    console.log(res);
                });
            });
    });
});