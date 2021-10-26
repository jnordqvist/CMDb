let title = document.querySelector("#previewTitle");
let poster = document.querySelector("#previewImg");
let link = document.querySelector("#searchLink");

let div = document.querySelector("#previewSearch");
const baseUrl = "https://www.omdbapi.com/?";
const key = "&apikey=f44c5f0a";


async function search() {
    
    let input = document.querySelector("#searchField").value;
    console.log(input)
     const response = await fetch(`${baseUrl}t=${input}${key}`).then(response => response.json())
    console.log(response)
    title.textContent = response.Title
    poster.src = response.Poster
    link.setAttribute("href", `/DetailPage/Movies/` + response.Title)

    //let template =
    //    `<a asp-controller="DetailPage" asp-action="Movies" asp-route-id="${response.Title}" href="@Url.Action("Movies", "DetailPage")?itemId=${response.Title}">`

    /*div.innerHTML = template + div.innerHTML + "</a>"*/

    console.log(response.Title)
}

document.querySelector("#searchField").addEventListener("input", search)