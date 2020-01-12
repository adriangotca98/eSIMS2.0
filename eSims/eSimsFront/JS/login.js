function verifyUsernameAndPassword(){
    var username = document.getElementById("username").value;
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange=function() {
        console.log(this.readyState);
        if (this.readyState==4){
            if (this.status==200){
                userData = JSON.parse(this.response);
                if (userData.Password==document.getElementById("password").value){
                    sessionStorage.setItem("username",username);
                    sessionStorage.setItem("typeOfUser",userData.TypeOfUser);
                    windows.location.replace("/index.html");
                }
                else {
                    alert("Wrong password!");
                }
            }
            if (this.status==404){
                alert("Username is not registered! Contact an admin for registering!");
            }
        }

    }
    xhttp.open("GET","https://localhost:44398/api/user/"+username,true);
    xhttp.send();
}