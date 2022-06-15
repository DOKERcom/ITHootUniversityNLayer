var _editUserModal = document.getElementById("_editUserModal");
var editUserModal = document.getElementById("editUserModal");
var span = document.getElementById("close_editUserModal");
editUserModal.onclick = function() {
    _editUserModal.style.display = "block";
}
span.onclick = function() {
    _editUserModal.style.display = "none";
}

var _checkUserModal = document.getElementById("_checkUserModal");
var checkUserModal = document.getElementById("checkUserModal");
var span = document.getElementById("close_checkUserModal");
checkUserModal.onclick = function () {
    _checkUserModal.style.display = "block";
}
span.onclick = function () {
    _checkUserModal.style.display = "none";
}