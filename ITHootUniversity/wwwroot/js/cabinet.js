
function UpdateUser(userName, password, userRole) {
    ReplaceElement("modal_body_text_id", "p", "modal_body_text_p_id", null, null, "Do you really want to update user?", null, null);
    modalConfirm(function (confirm) {
        if (confirm) {
            const request = new XMLHttpRequest();
            const url = "/Cabinet/CreateOrUpdateUser";
            const params = "UserName=" + userName + "&Password=" + password + "&Role=" + userRole;
            request.open("POST", url, true);
            request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            request.addEventListener("readystatechange", () => {
                if (request.readyState === 4 && request.status === 200) {
                    var json = JSON.parse(request.responseText);
                    window.location.href = "/Cabinet";
                }
            });

            request.send(params);
        }
    });
}

function CreateUser() {

            userName = document.getElementById('validationCustomUsername').value;
            password = document.getElementById('validationCustomPassword').value;
            userRole = document.getElementById('validationCustomRole').value;
            const request = new XMLHttpRequest();
            const url = "/Cabinet/CreateOrUpdateUser";
            const params = "UserName=" + userName + "&Password=" + password + "&Role=" + userRole;
            request.open("POST", url, true);
            request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            request.addEventListener("readystatechange", () => {
                if (request.readyState === 4 && request.status === 200) {
                    var json = JSON.parse(request.responseText);
                    window.location.href = "/Cabinet";
                }
            });

            request.send(params);
        }


function DeleteUser(login) {
    ReplaceElement("modal_body_text_id", "p", "modal_body_text_p_id", null, null, "Do you realy want to delete user?", null, null);
    modalConfirm(function (confirm) {
        if (confirm) {

            const request = new XMLHttpRequest();
            const url = "/Cabinet/DeleteUser";
            const params = "userName=" + login;
            request.open("POST", url, true);
            request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            request.addEventListener("readystatechange", () => {
                if (request.readyState === 4 && request.status === 200) {
                    //var json = JSON.parse(request.responseText);
                    //alert(json.resultMessage);
                    window.location.href = "/Cabinet";
                }
            });
            request.send(params);

        }
    });
}

function CreateLesson() {

    var lessonName = document.getElementById('validationCustomLessonname').value;
    var userName = document.getElementById('validationCustomTeacher').value;

    const request = new XMLHttpRequest();
    const url = "/Cabinet/CreateLesson";
    const params = "lessonName=" + lessonName + "&userName=" + userName;
    request.open("POST", url, true);
    request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    request.addEventListener("readystatechange", () => {
        if (request.readyState === 4 && request.status === 200) {
            //var json = JSON.parse(request.responseText);
            //alert(json.resultMessage);
            window.location.href = "/Cabinet";
        }
    });
    request.send(params);

}

function DeleteLesson(lessonName) {
    ReplaceElement("modal_body_text_id", "p", "modal_body_text_p_id", null, null, "Do you really want to delete lesson (" + lessonName + ")?", null, null);
    modalConfirm(function (confirm) {
        if (confirm) {
            if (lessonName.length > 0) {
                const request = new XMLHttpRequest();
                const url = "/Cabinet/DeleteLesson";
                const params = "lessonName=" + lessonName;
                request.open("POST", url, true);
                request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
                request.addEventListener("readystatechange", () => {
                    if (request.readyState === 4 && request.status === 200) {
                        //var json = JSON.parse(request.responseText);
                        //alert(json.resultMessage);
                        window.location.href = "/Cabinet";
                    }
                });
                request.send(params);
            } else {
                alert("LessonName must be filled!");
            }
        }
    });

}

function AddUserToLesson(lessonName, userName, role) {
    if (lessonName.length > 0 && userName.length > 0) {
        const request = new XMLHttpRequest();
        const url = "/Cabinet/AddUserToLesson";
        const params = "lessonName=" + lessonName + "&userName=" + userName;
        request.open("POST", url, true);
        request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        request.addEventListener("readystatechange", () => {
            if (request.readyState === 4 && request.status === 200) {
                var json = JSON.parse(request.responseText);
                new Toast({
                    title: 'Successfull',
                    text: json.resultMessage,
                    theme: 'success',
                    autohide: true,
                    interval: 3000
                });
                GetCheckUserUpd(userName, role);
            }
        });
        request.send(params);
    } else {
        alert("LessonName and Login must be filled!");
    }
}

function DelUserFromLesson(lessonName, userName, role) {
    ReplaceElement("modal_body_text_id", "p", "modal_body_text_p_id", null, null, "Do you really want to remove user (" + userName + ") from lesson (" + lessonName + ")?", null, null);
    modalConfirm(function (confirm) {
        if (confirm) {

            if (lessonName.length > 0 && userName.length > 0) {
                const request = new XMLHttpRequest();
                const url = "/Cabinet/DelUserFromLesson";
                const params = "lessonName=" + lessonName + "&userName=" + userName;
                request.open("POST", url, true);
                request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
                request.addEventListener("readystatechange", () => {
                    if (request.readyState === 4 && request.status === 200) {
                        var json = JSON.parse(request.responseText);
                        new Toast({
                            title: 'Successfull',
                            text: json.resultMessage,
                            theme: 'success',
                            autohide: true,
                            interval: 3000
                        });
                        GetCheckUserUpd(userName, role);
                    }
                });
                request.send(params);
            } else {
                alert("LessonName and Login must be filled!");
            }

        }
    });
}

function JoinToLesson(lessonName) {
    if (lessonName.length > 0) {
        const request = new XMLHttpRequest();
        const url = "/Cabinet/JoinToLesson";
        const params = "lessonName=" + lessonName;
        request.open("POST", url, true);
        request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        request.addEventListener("readystatechange", () => {
            if (request.readyState === 4 && request.status === 200) {
                var json = JSON.parse(request.responseText);
                alert(json.resultMessage);
                window.location.href = "/Cabinet";
            }
        });
        request.send(params);
    } else {
        alert("LessonName must be filled!");
    }
}

function LeftFromLesson(lessonName) {
    if (confirm("Do you really want to left the lesson (" + lessonName + ")?") == true) {
        if (lessonName.length > 0) {
            const request = new XMLHttpRequest();
            const url = "/Cabinet/LeftFromLesson";
            const params = "lessonName=" + lessonName;
            request.open("POST", url, true);
            request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            request.addEventListener("readystatechange", () => {
                if (request.readyState === 4 && request.status === 200) {
                    var json = JSON.parse(request.responseText);
                    alert(json.resultMessage);
                    window.location.href = "/Cabinet";
                }
            });
            request.send(params);
        } else {
            alert("LessonName must be filled!");
        }
    }
}