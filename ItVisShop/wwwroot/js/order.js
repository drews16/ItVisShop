const tabsOrderHead = document.querySelectorAll(".order-tab")
const tabsOrderContent = document.querySelectorAll(".order-items")

tabsOrderHead.forEach((tab, index) => {
    tab.addEventListener("click", () => {
        changeOrderTab(index);
    });
});

function changeOrderTab(index) {
    setOrderActiveClass(tabsOrderHead, index);
    setOrderActiveClass(tabsOrderContent, index);
}

function setOrderActiveClass(arr, index) {
    for (let el of arr) {
        el.classList.remove("active");
    }

    arr[index].classList.add("active");
}