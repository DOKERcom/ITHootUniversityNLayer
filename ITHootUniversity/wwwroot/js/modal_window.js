var _editUserModal = document.getElementById("_editUserModal");
var editUserModal = document.getElementById("editUserModal");
var span = document.getElementById("close_editUserModal");
span.onclick = function() {
    _editUserModal.style.display = "none";
}
function EditUserModal(login) {
    if (login.length > 0) {
        _editUserModal.style.display = "block";
    } else {
        alert("Username Undefined");
    }
}

var _checkUserModal = document.getElementById("_checkUserModal");
var checkUserModal = document.getElementById("checkUserModal");
var span = document.getElementById("close_checkUserModal");
span.onclick = function () {
    _checkUserModal.style.display = "none";
}
function CheckUserModal(login) {
    if (login.length > 0) {
        _checkUserModal.style.display = "block";
    } else {
        alert("Username Undefined");
    }
}



var _createUserModal = document.getElementById("_createUserModal");
var createUserModal = document.getElementById("createUserModal");
var span = document.getElementById("close_createUserModal");
createUserModal.onclick = function () {
    _createUserModal.style.display = "block";
}
span.onclick = function () {
    _createUserModal.style.display = "none";
}