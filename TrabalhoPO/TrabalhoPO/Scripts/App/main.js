﻿$(document).ready(function () {
    $(".input-validation-error").parents(".form-group").addClass("has-error");
});

$(document).on("hidden.bs.modal", ".modal", function () {
    $(this).remove();
    //history.go(-1);
});

function isJson(str) {
    try {
        JSON.parse(str);
    } catch (e) {
        return false;
    }
    return true;
}

function appendModal(id) {
    $("body").append("<div id='" + id + "' class='modal fade in' role='dialog'></div>");
}

function showModal(id, data) {
    appendModal(id);
    $("#" + id).html(data).modal("show");
}

$("a[data-toggle=modal]").on("click", function () {
    var id = $(this).data("target");
    appendModal(id);
    $("#" + id).load(this.href).modal("show");
});

function modal(Modal, Tipo) {
    var url = "/Home/Modal";
    if (!isJson(Modal)) {
        Modal = "{ 'Mensagem':'" + Modal + "'}";
    }
    $.get(url, { jsonModal: Modal, tipo: Tipo }, function (data) {
        showModal(data.Id, data)
    });
}

function exclui(Model, Id) {
    var url = "/" + Model + "/Excluir";
    $.post(url, { id: Id }, function (resposta) {
        if ($("#" + Model + Id).length) {
            $("#" + Model + Id).remove();
        }
        else {
            window.location.href = "/" + Model + "/Index";
        }
    });
}