// Настройки для меню бургер
const burger = document.querySelector(".burger")
const nav = document.querySelector(".navigation")
const body = document.querySelector("body")
document.querySelector(".burger").addEventListener("click", async e => {
    burger.classList.toggle("active")
    nav.classList.toggle("active")
    body.classList.toggle("lock")
})