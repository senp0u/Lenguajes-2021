// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//this function loads the website


$(document).ready(function () {
    LoadData();
    GetServices();
    GetSupervisor();
});

function LoadData() {
    $.ajax({
        url: "/Issue/GetIssues",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            var employee = '';

            var idSupporter = document.getElementById('id-employee').value;

            var isSupervisor = document.getElementById('supervisor').value;

            $.each(result, function (key, item) {

                if (isSupervisor == 1) {

                    html += '<tr>';
                    html += '<td>' + item.classification + '</td>';
                    html += '<td>' + item.status + '</td>';
                    html += '<td>' + item.reportDate + '</td>';
                    html += '<td>' + item.resolutionComment + '</td>';
                    html += '<td>' + item.service.name + '</td>';


                    if (item.employeeId == null) {
                        html += '<td><a href="#openModal" data-toggle="modal" onclick="return GetById(' + item.reportNumber + ')">Asignar</a></td>';
                    }
                    else {
                        html += '<td>Asignado</td>';
                    }

                } else if (idSupporter == item.employeeId) {

                    html += '<tr>';
                    html += '<td>' + item.classification + '</td>';
                    html += '<td>' + item.status + '</td>';
                    html += '<td>' + item.reportDate + '</td>';
                    html += '<td>' + item.resolutionComment + '</td>';
                    html += '<td>' + item.service.name + '</td>';
                    html += '<td><a href="#resolved" data-toggle="modal" onclick="return GetById(' + item.ReportNumber + ')">Resolver</a></td>';
                }
                
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
            "infoFiltered": "(filtrado de _MAX_ registros en total)",
            "loadingRecords": "Cargando...",
            "search": "Buscar: ",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": ">",
                "previous": "<"
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

                var checkbox = document.createElement('input');
                checkbox.type = "checkbox";
                checkbox.name = item.name;
                checkbox.value = item.serviceId;
                checkbox.id = item.name;
                checkbox.style = "margin-left:30px";

                var label = document.createElement('label')
                label.htmlFor = item.name;
                label.appendChild(document.createTextNode('' + item.name));
                label.style = "margin-left:10px";

                $("#form-check").append(checkbox);
                $("#form-check").append(label);
            });
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}




function GetSupervisor() {
    $.ajax({
        url: "/Employee/GetSupervisor",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            $.each(result, function (key, item) {
                $("#option-supervisor").append('<option value=' + item.employeeId + '>' + item.name + ' ' + item.firstSurname + ' ' + item.secondSurname +'</option>');
            });
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })
}

function AddEmployee() {

    document.getElementById('name').value = '';
    document.getElementById('first-surname').value = '';
    document.getElementById('second-surname').value = '';
    document.getElementById('email').value = '';
    document.getElementById('password').value = '';

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

function GetById(issueId) {
    
    $.ajax({
        url: "/Issue/GetIssueById/" + issueId,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            document.getElementById('id-issue').value = result['reportNumber'];
            document.getElementById('classification').value = result['classification'];
            document.getElementById('status').value = result['status'];
            document.getElementById('report-date').value = result['reportDate'];
            document.getElementById('resolution').value = result['resolutionComment'];
            document.getElementById('note').value = result.notes['description'];
            FillSuporterSelector();
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}

function FillSuporterSelector() {
    $.ajax({
        url: "/Employee/GetNonSupervisors",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            let selector = $("#option-supporter");
            $.each(result, function (key, item) {
                let option = document.createElement('option');
                option.value = item.employeeId;
                option.innerHTML = item.name + ' ' + item.firstSurname;
                selector.append(option);
            });
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}

//So ist es immer
function IssueUpdate() {
    let issue = {
        "reportNumber": $('#id-issue').val(),
        "employeeId": $('#option-supporter').val()
    }

    $.ajax({
        url: "/Issue/PutAssignEmployee",
        data: JSON.stringify(issue),
        type: "PUT",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
           
        },
        error: function (errorMessage) {
            alert(errorMessage);
        }
    });
}

function Clear() {

    document.getElementById('name').value = '';
    document.getElementById('first-surname').value = '';
    document.getElementById('second-surname').value = '';
    document.getElementById('email').value = '';
    document.getElementById('password').value = '';
}
