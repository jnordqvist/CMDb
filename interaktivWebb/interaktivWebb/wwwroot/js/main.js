
const expandPlot = () => {
    
    var target = event.target
    var parent = target.parentNode.parentNode
    console.log("target")

    console.log(parent.childNodes)
    console.log(parent.firstChild)
    console.log(parent.childNodes[1])

    if (parent.lastChild.style.display == "none") {

        parent.firstChild.style.display = "none"
        parent.lastChild.style.display = "inline"
        parent.lastChild.lastChild.style.marginLeft = "5px"
        
    }
    else {
        parent.firstChild.style.display = "inline"
        parent.lastChild.style.display = "none"
        
    }
    
    
   
}

let links = document.querySelectorAll(".expandPlot")
links.forEach(element => element.addEventListener("click", expandPlot))

