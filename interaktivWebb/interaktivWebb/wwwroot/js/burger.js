let burgerMenuOpen = false

const slideBurgerOut = () => {
    let menu = document.querySelector("#burgermenu")
    menu.style.left = "0px"
    document.querySelector("#burger").src = "/images/burgerOpenWhite.svg"
    burgerMenuOpen = true;
}

const slideBurgerIn = () => {
    let menu = document.querySelector("#burgermenu")
    menu.style.left = "-100%"
    document.querySelector("#burger").src = "/images/burgerClosedWhite.svg"
    burgerMenuOpen = false;
}

const toggleBurger = () => {
    if (burgerMenuOpen) {
        return slideBurgerIn()
    }
    else {
        return slideBurgerOut()
    }
}

document.querySelector("#burger").addEventListener('click', toggleBurger)