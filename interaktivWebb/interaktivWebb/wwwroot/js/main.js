
const expandPlot = () => {
    console.log("target")
    var target = event.target
    var parent = target.parentNode.parentNode
    console.log(parent.childNodes)
    console.log(parent.firstChild)
    console.log(parent.lastChild)
    parent.firstChild.style.visibility = "hidden"
    parent.lastChild.style.visibility = "visible"

}

let links = document.querySelectorAll(".expandPlot")
links.forEach(element => element.addEventListener("click", expandPlot))
