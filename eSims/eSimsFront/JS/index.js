var ul=document.createElement('ul');
var p=document.createElement('p');
var xhttp = new XMLHttpRequest();
xhttp.onreadystatechange=function() {
    console.log(this.readyState);
    if (this.readyState==4&&this.status==200){
        student = JSON.parse(this.response);
        console.log(student.Subjects);
        var lastN=student.LastName;
        var firstN=student.FirstName;
        var an=student.Year;
        var grupa=student.Group;
        var materii="Lista materii:";
        p.textContent+="Hello, "+lastN+" "+firstN+'!';
        document.getElementById("content").append(p);
        p.textContent="An: "+an;
        document.getElementById("content").append(p);
        p.textContent="Grupa: "+grupa;
        document.getElementById("content").append(p)
        p.textContent=materii;
        document.getElementById("content").append(p)
        for (subject of student.Subjects){
            var li=document.createElement('li');
            li.textContent=subject;
            ul.append(li);
        }
        document.getElementById("content").append(ul)
    }
}
xhttp.open("GET","https://localhost:44398/api/student/1",true);
xhttp.send();