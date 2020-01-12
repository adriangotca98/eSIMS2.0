var p;
var xhttp = new XMLHttpRequest();
xhttp.onreadystatechange=function() {
    console.log(this.readyState);
    if (this.readyState==4&&this.status==200){
        student = JSON.parse(this.response);
        console.log(student);
        var lastN=student.LastName;
        var firstN=student.FirstName;
        var an=student.Year;
        var grupa=student.Group;
        p=document.createElement('h3');
        p.textContent+="Hello, "+lastN+" "+firstN+'!';
        document.getElementById("content").append(p);
        p=document.createElement('p');
        p.textContent="An: "+an;
        document.getElementById("content").append(p);
        p=document.createElement('p');
        p.textContent="Grupa: "+grupa;
        document.getElementById("content").append(p)
    }
}
xhttp.open("GET","https://localhost:44398/api/student/1",true);
xhttp.send();