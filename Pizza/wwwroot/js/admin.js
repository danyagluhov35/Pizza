// ��������� ��������
const arrowSideBar = document.querySelector(".sideBarArrow")
const sidebar = document.querySelector(".sidebar")
arrowSideBar.addEventListener("click", async e => {
    e.preventDefault()
    arrowSideBar.classList.toggle("open")
    sidebar.classList.toggle("open")
})

// ��������� �������� � �������� ���� ���������� ��������
const addBlockSet = document.querySelector(".addblock-settings")

document.querySelector(".addblock").addEventListener("click", async e => {
    addBlockSet.classList.add("open")
})
document.querySelector(".close").addEventListener("click", async e => {
    addBlockSet.classList.remove("open")
})

// �������� ��-�� 
document.querySelectorAll(".delete").forEach(element => {
    element.addEventListener("click", async e => {
        const element = e.target.parentNode.parentNode.parentNode
        element.style.display = "none"
    })
});