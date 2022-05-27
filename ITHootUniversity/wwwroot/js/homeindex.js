
function AuthFunc(login, password) {
    if (login.length > 0 && password.length > 0) {
        const request = new XMLHttpRequest();
        const url = "/Home/SignIn";
        const params = "UserName=" + login + "&Password=" + password;
        request.open("POST", url, true);
        request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        request.addEventListener("readystatechange", () => {
            if (request.readyState === 4 && request.status === 200) {
                var json = JSON.parse(request.responseText);
                if (json.resultAction != "ok") {
                    alert(json.resultMessage);
                }
                else {
                    window.location.href = "/Cabinet";
                }
            }
        });
        request.send(params);
    }
    else {
        alert("Login and password must be filled!");
    }
}