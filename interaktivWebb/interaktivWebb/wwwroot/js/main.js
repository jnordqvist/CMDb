let rankings = document.querySelectorAll(".rank")
let rankNr = 1
for (var rank in rankings) {
    rankings[rank].innerHTML = String(rankNr)
    rankNr += 1
}

const expandPlot = () => {
    
    var target = event.target
    var parent = target.parentNode.parentNode

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


