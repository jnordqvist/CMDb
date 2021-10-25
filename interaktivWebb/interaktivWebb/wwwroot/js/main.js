
const expandPlot = () => {
    
    var target = event.target
    var parent = target.parentNode
    console.log("target")

    console.log(parent.childNodes)
    console.log(parent.firstChild)
    console.log(parent.childNodes[1])

    if (parent.lastChild.textContent == "Read More") {

        parent.firstChild.style.visibility = "hidden"
        parent.childNodes[1].style.visibility = "visible"
        parent.lastChild.textContent = "Read Less"
    }
    else {
        parent.firstChild.style.visibility = "visible"
        parent.childNodes[1].style.visibility = "hidden"
        parent.lastChild.textContent = "Read More"
    }
    
    
   
}

let links = document.querySelectorAll(".expandPlot")
links.forEach(element => element.addEventListener("click", expandPlot))

