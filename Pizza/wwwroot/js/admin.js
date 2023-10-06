// Настройка сайдбара
const arrowSideBar = document.querySelector(".sideBarArrow")
const sidebar = document.querySelector(".sidebar")
arrowSideBar.addEventListener("click", async e => {
    e.preventDefault()
    arrowSideBar.classList.toggle("open")
    sidebar.classList.toggle("open")
})

// Настройка открытия и закрытия окна добавления контента
const addBlockSet = document.querySelector(".addblock-settings")

document.querySelector(".addblock").addEventListener("click", async e => {
    addBlockSet.classList.add("open")
})
document.querySelector(".close").addEventListener("click", async e => {
    addBlockSet.classList.remove("open")
})

// Удаление эл-та 
document.querySelectorAll(".delete").forEach(element => {
    element.addEventListener("click", async e => {
        const element = e.target.parentNode.parentNode.parentNode
        element.style.display = "none"
    })
});

const editBlockSet = document.querySelectorAll(".edit").forEach((e) => {
    e.addEventListener("click", async c => {


        var res = e.parentNode.parentNode.getAttribute("id")
        var item = document.getElementById(res).getElementsByTagName("td")

        const label = document.createElement("label")
        const file = document.createElement("input")
        const span = document.createElement("span")

        label.classList.add("input-file")
        file.classList.add("file")
        file.type = "file"
        span.textContent = "Выберите файл"

        file.addEventListener("change", async e => {
            span.textContent = e.target.files[0].name
        })

        label.append(file)
        label.append(span)

        item[1].replaceChild(document.createElement("input"), item[1].firstChild)
        item[2].replaceChild(label, item[2].firstChild)
        item[3].replaceChild(document.createElement("input"), item[3].firstChild)


        const editSave = document.createElement("a")
        const editSaveImg = document.createElement("img")
        editSaveImg.src = "/images/adminImage/save.svg"
        editSave.append(editSaveImg)
        editSave.classList.add("editSave")
        c.target.parentNode.parentNode.replaceChild(editSave, e)

        const editClose = document.createElement("a");
        const editCloseImg = document.createElement("img")
        editCloseImg.src = "/images/adminImage/close.svg"
        editClose.append(editCloseImg)
        editClose.classList.add("editClose")

        editClose.href = "#"
        var tdEditClode = editSave.parentNode.nextElementSibling
        console.log(tdEditClode)
        console.log(tdEditClode.firstChild)
        tdEditClode.replaceChild(editClose, tdEditClode.firstChild)
        console.log(tdEditClode.childNodes[0])

        editClose.addEventListener("click", async v => {
            alert("На данный момент функция не работает")
        })

    })
})