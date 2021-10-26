
const expandPlot = () => {
    
    var target = event.target
    var parent = target.parentNode
    console.log("target")

    console.log(parent.childNodes)
    console.log(parent.firstChild)
    console.log(parent.childNodes[1])

    if (parent.lastChild.textContent == "Read More") {

        parent.firstChild.style.display = "none"
        parent.childNodes[1].style.display = "flex"
        parent.lastChild.textContent = "Read Less"
    }
    else {
        parent.firstChild.style.display = "flex"
        parent.childNodes[1].style.display = "none"
        parent.lastChild.textContent = "Read More"
    }
    
    
   
}

let links = document.querySelectorAll(".expandPlot")
links.forEach(element => element.addEventListener("click", expandPlot))

