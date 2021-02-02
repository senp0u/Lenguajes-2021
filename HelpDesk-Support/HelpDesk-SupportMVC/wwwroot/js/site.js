// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//this function loads the website
$(document).ready(function () {
    LoadData();
    GetServices();
});

function LoadData() {
    $.ajax({
        url: "/Issue/GetIssues",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.reportNumber + '</td>';
                html += '<td>' + item.classification + '</td>';
                html += '<td>' + item.status + '</td>';
                html += '<td>' + item.reportDate + '</td>';
                html += '<td>' + item.resolutionComment + '</td>';
                html += '<td>' + item.serviceId + '</td>';
                html += '<td><a href="#openModal" onclick="return GetById(' + item.ReportNumber + ')">Asignar</a></td>';
            });
            $('.tbody').html(html);
            TableLanguage();
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })

}

function TableLanguage() {
    $('#table').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ registros por página",
            "zeroRecords": "No encontrado, siga intentando",
            "info": "Mostrando _PAGE_ de _PAGES_",
            "infoEmpty": "No hay registros disponibles",
            "infoFiltered": "(filtered from _MAX_ total records)",
            "loadingRecords": "Cargando...",
            "search": "Buscar: ",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "pagingType": "full_numbers"
    });
}

function GetServices() {
    $.ajax({
        url: "/Service/GetServices",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            $.each(result, function (key, item) {
                $("#option-services").append('<option value=' + item.serviceId + '>' + item.name + '</option>');
            });
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })
}

function AddEmployee() {
    let isSupervisor = false;
    var ServiceList = [{
        //employeeId = 2
        serviceId: 1,
        createBy: 3,
        createDate: "2004-05-23T14:25:10"
        }];

    if ($('#is-supervisor').val()=="Si") {
        isSupervisor = true;
    }

    var employee = {

        name: $('#name').val(),
        firstSurname: $('#first-surname').val(),
        secondSurname: $('#second-surname').val(),
        email: $('#email').val(),
        supervisorId:3,
        isSupervisor: isSupervisor,
        employeeServices: ServiceList,
        password: $('#password').val(),
        createBy: 3,
        createDate: "2004-05-23T14:25:10"

    };

    $.ajax({
        url: "/Employee/PostEmployee",
        data: JSON.stringify(employee),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            document.getElementById('name').value = '';
            document.getElementById('first-surname').value = '';
            document.getElementById('second-surname').value = '';
            document.getElementById('email').value = '';
            document.getElementById('password').value = '';
            LoadData();
            ShowLabel('message');
            document.getElementById('message').innerHTML = 'El Empleado se registró exitosamente';
        },
        error: function (errorMessage) {
            ShowLabel('message');
            document.getElementById('message').innerHTML = 'El Empleado no se logró registrar';
        }
    });

}

function ShowLabel(id) {

    document.getElementById(id).style.visibility = "visible";

}
