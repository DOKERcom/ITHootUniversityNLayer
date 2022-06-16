var _editUserModal = document.getElementById("_editUserModal");
var editUserModal = document.getElementById("editUserModal");
var span = document.getElementById("close_editUserModal");
span.onclick = function() {
    _editUserModal.style.display = "none";
}
function EditUserModal(login) {
    if (login.length > 0) {

        ReplaceElement("edit_header_name_id", "p", "edit_userlogin_id", null, null, login, null, null);

        ReplaceElement("edit_changepassword_id", "input", "inputedit_changepassword_id", "Change password", "submit",null, "onclick", "CreateOrUpdateUser('" + login + "', document.getElementById('EditPassword').value, '')");

        ReplaceElement("edit_changerole_id", "input", "inputedit_changerole_id", "Change role", "submit", null, "onclick", "CreateOrUpdateUser('" + login + "', '', document.getElementById('EditRole').value)");

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

function CheckUserModal(login, role) {
    if (login.length > 0) {

        ReplaceElement("userinfo_username_id", "p", "userinfo_username_child", null, null, login, null, null);

        ReplaceElement("userinfo_userrole_id", "p", "userinfo_userrole_child", null, null, role, null, null);

        var cabinetViewModel;

        const request = new XMLHttpRequest();
        const url = "/Cabinet/GetJsonCabinetViewModel";
        request.open("POST", url, false);
        request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        request.addEventListener("readystatechange", () => {
            if (request.readyState === 4 && request.status === 200) {
                cabinetViewModel = JSON.parse(request.responseText);
            }
        });
        request.send();

        var users = cabinetViewModel.userViewModels;

        var alllessons = cabinetViewModel.lessonViewModels;

        alllessons.forEach(function (lesson) {
            ReplaceElement("user_buttons_" + lesson.lessonName +"_id", "input", "id_" + lesson.lessonName + "_lessonname", null, "checkbox", role, "onclick", "AddUserToLesson('" + lesson.lessonName + "', '" + login +"')");
        });

        users.forEach(function (user) {
            if (user.userName == login)
                user.lessons.forEach(function (lesson) {
                    ReplaceElement("user_buttons_" + lesson.lessonName +"_id", "input", "id_" + lesson.lessonName + "_lessonname", null, "checkbox", role, "onclick", "DelUserFromLesson('" + lesson.lessonName + "', '" + login + "')");
                    var item = document.getElementById("id_" + lesson.lessonName + "_lessonname");
                    console.log(lesson.lessonName);
                    item.checked = true;
                });
        });

        _checkUserModal.style.display = "block";
    } else {
        alert("Username Undefined");
    }
}

var _createLessonModal = document.getElementById("_createLessonModal");
var createLessonModal = document.getElementById("createLessonModal");
var span = document.getElementById("close_createLessonModal");
createLessonModal.onclick = function () {
    _createLessonModal.style.display = "block";
}
span.onclick = function () {
    _createLessonModal.style.display = "none";
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









function ReplaceElement(motherAttributeId, attribute, attributeId, attributeValue, attributeType, attributeInnerHtml, setAttributeType, setAttributeValue) {

    if (motherAttributeId != null && attribute != null && attributeId != null) {
        var editchangepass = document.createElement(attribute);

        editchangepass.id = attributeId;

        if (attributeValue != null)
            editchangepass.value = attributeValue;
        if (attributeType != null)
            editchangepass.type = attributeType;
        if (attributeInnerHtml != null)
            editchangepass.innerHTML = attributeInnerHtml;


        if (setAttributeType != null && setAttributeValue != null)
            editchangepass.setAttribute(setAttributeType, setAttributeValue);

        document.getElementById(motherAttributeId).childNodes.forEach(function (child) {
            if (child.id == attributeId)
                document.getElementById(motherAttributeId).removeChild(document.getElementById(attributeId));
        });
                
        document.getElementById(motherAttributeId).insertBefore(editchangepass, document.getElementById(motherAttributeId).firstChild);
    }
}