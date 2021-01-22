// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//this function loads the website
$(document).ready(function () {
    LoadData();
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
                html += '<td><a href="#openModal" onclick="return GetById(' + item.ReportNumber + ')">Edit</a> | <a href="#modalDelete" onclick="Delete(' + item.ReportNumber + ')">Delete</a></td>';
            });
            $('.tbody').html(html);

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
            document.getElementById('email').value = '';
            document.getElementById('password').value = '';
            LoadData();
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

}