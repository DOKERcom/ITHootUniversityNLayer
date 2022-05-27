﻿function CreateOrUpdateUser(login, password, username, usertype) {
    if (login.length > 0) {
        const request = new XMLHttpRequest();
        const url = "/Cabinet/CreateOrUpdateUser";
        const params = "Id=" + "&Login=" + login + "&Password=" + password + "&UserName=" + username + "&UserType=" + usertype + "&SessionKey=";
        request.open("POST", url, true);
        request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        request.addEventListener("readystatechange", () => {
            if (request.readyState === 4 && request.status === 200) {
                var json = JSON.parse(request.responseText);
                if (json.resultAction == "logout") {
                    window.location.href = "/Home/Logout";
                }
                else {
                    alert(json.resultMessage);
                    window.location.href = "/Cabinet";
                }
            }
        });
        request.send(params);
    } else {
        alert("Login must be filled!");
    }
}

function DeleteUser(login) {
    const request = new XMLHttpRequest();
    const url = "/Cabinet/DeleteUser";
    const params = "Login=" + login;
    request.open("POST", url, true);
    request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    request.addEventListener("readystatechange", () => {
        if (request.readyState === 4 && request.status === 200) {
            var json = JSON.parse(request.responseText);
            if (json.resultAction == "logout") {
                window.location.href = "/Home/Logout";
            }
            else {
                alert(json.resultMessage);
                window.location.href = "/Cabinet";
            }
        }
    });
    request.send(params);
}

function CreateLesson(lessonName, login) {
    if (lessonName.length > 0 && login.length > 0) {
        const request = new XMLHttpRequest();
        const url = "/Cabinet/CreateLesson";
        const params = "LessonName=" + lessonName + "&Login=" + login;
        request.open("POST", url, true);
        request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        request.addEventListener("readystatechange", () => {
            if (request.readyState === 4 && request.status === 200) {
                var json = JSON.parse(request.responseText);
                if (json.resultAction == "logout") {
                    window.location.href = "/Home/Logout";
                }
                else {
                    alert(json.resultMessage);
                    window.location.href = "/Cabinet";
                }
            }
        });
        request.send(params);
    } else {
        alert("LessonName and Login must be filled!");
    }
}

function DeleteLesson(lessonName) {
    if (lessonName.length > 0) {
        const request = new XMLHttpRequest();
        const url = "/Cabinet/DeleteLesson";
        const params = "LessonName=" + lessonName;
        request.open("POST", url, true);
        request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        request.addEventListener("readystatechange", () => {
            if (request.readyState === 4 && request.status === 200) {
                var json = JSON.parse(request.responseText);
                if (json.resultAction == "logout") {
                    window.location.href = "/Home/Logout";
                }
                else {
                    alert(json.resultMessage);
                    window.location.href = "/Cabinet";
                }
            }
        });
        request.send(params);
    } else {
        alert("LessonName must be filled!");
    }
}

function AddUserToLesson(lessonName, login) {
    if (lessonName.length > 0 && login.length > 0) {
        const request = new XMLHttpRequest();
        const url = "/Cabinet/AddUserToLesson";
        const params = "LessonName=" + lessonName +"&Login=" + login;
        request.open("POST", url, true);
        request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        request.addEventListener("readystatechange", () => {
            if (request.readyState === 4 && request.status === 200) {
                var json = JSON.parse(request.responseText);
                if (json.resultAction == "logout") {
                    window.location.href = "/Home/Logout";
                }
                else {
                    alert(json.resultMessage);
                    window.location.href = "/Cabinet";
                }
            }
        });
        request.send(params);
    } else {
        alert("LessonName and Login must be filled!");
    }
}

function DelUserFromLesson(lessonName, login) {
    if (lessonName.length > 0 && login.length > 0) {
    const request = new XMLHttpRequest();
    const url = "/Cabinet/DelUserFromLesson";
    const params = "LessonName=" + lessonName + "&Login=" + login;
    request.open("POST", url, true);
    request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    request.addEventListener("readystatechange", () => {
        if (request.readyState === 4 && request.status === 200) {
            var json = JSON.parse(request.responseText);
            if (json.resultAction == "logout") {
                window.location.href = "/Home/Logout";
            }
            else {
                alert(json.resultMessage);
                window.location.href = "/Cabinet";
            }
        }
    });
        request.send(params);
    } else {
        alert("LessonName and Login must be filled!");
    }
}

function JoinToLesson(lessonName) {
    if (lessonName.length > 0) {
        const request = new XMLHttpRequest();
        const url = "/Cabinet/JoinToLesson";
        const params = "LessonName=" + lessonName;
        request.open("POST", url, true);
        request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        request.addEventListener("readystatechange", () => {
            if (request.readyState === 4 && request.status === 200) {
                var json = JSON.parse(request.responseText);
                if (json.resultAction == "logout") {
                    window.location.href = "/Home/Logout";
                }
                else {
                    alert(json.resultMessage);
                    window.location.href = "/Cabinet";
                }
            }
        });
        request.send(params);
    } else {
        alert("LessonName must be filled!");
    }
}

function LeftFromLesson(lessonName) {
    if (lessonName.length > 0) {
        const request = new XMLHttpRequest();
        const url = "/Cabinet/LeftFromLesson";
        const params = "LessonName=" + lessonName;
        request.open("POST", url, true);
        request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        request.addEventListener("readystatechange", () => {
            if (request.readyState === 4 && request.status === 200) {
                var json = JSON.parse(request.responseText);
                if (json.resultAction == "logout") {
                    window.location.href = "/Home/Logout";
                }
                else {
                    alert(json.resultMessage);
                    window.location.href = "/Cabinet";
                }
            }
        });
        request.send(params);
    } else {
        alert("LessonName must be filled!");
    }
}