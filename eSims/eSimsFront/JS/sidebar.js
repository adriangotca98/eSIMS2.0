var div=document.getElementsByClassName("wrapper")[0];
var nav=document.createElement('nav');
nav.setAttribute("id","sidebar");
var ul=document.createElement('ul');
var divSidebarHeader=document.createElement('div');
var h3SidebarHeader=document.createElement('h3');
divSidebarHeader.className="sidebar-header";
h3SidebarHeader.textContent="eSIMS 2.0";
divSidebarHeader.append(h3SidebarHeader);
nav.append(divSidebarHeader);
ul.classList.add("list-unstyled","components");
var p=document.createElement('p');
p.textContent="Menu";
ul.append(p);
var xhttp = new XMLHttpRequest();
xhttp.onreadystatechange=function() {
    console.log(this.readyState);
    if (this.readyState==4&&this.status==200){
        student = JSON.parse(this.response);
        console.log(student.Subjects);
        for (subject of student.Subjects){
            var li=document.createElement('li');
            var a  = document.createElement('a');
            a.setAttribute('href','#'+subject);
            a.textContent=subject;
            if (subject==document.title)
                li.className="active";
            li.append(a);
            ul.append(li);
        }
        console.log(ul.innerHTML);
        nav.append(ul);
        console.log(nav.innerHTML);
        div.insertBefore(nav, document.getElementById("content"));
        console.log(div.innerHTML);
    }
}
xhttp.open("GET","https://localhost:44398/api/student/1",true);
xhttp.send();