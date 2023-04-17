const plusBtns = document.querySelectorAll("#btn-plus");
const minusBtns = document.querySelectorAll("#btn-minus");
const totalCountElement = document.getElementById("cart-total-count");
const totalPriceElement = document.getElementById("cart-total-price");

let cartTotalCount = parseInt(document.getElementById("cart-total-count").innerHTML);
let cartTotalStr = document.getElementById("cart-total-price").innerHTML.replace(/&nbsp;/g, "");

if (cartTotalStr[0] == "$") {
    cartTotalStr = cartTotalStr.replace("$", "").replace(/,/g, "")
}

let cartTotalPrice = parseFloat(cartTotalStr);

const formatter = new Intl.NumberFormat("ru", {
    style: "currency",
    currency: "RUB"
});

plusBtns.forEach((el, index) =>
    el.addEventListener("click", () => {
        let itemPriceStr = document.querySelectorAll("#cart-item__price")[index].innerHTML.replace(/&nbsp;/g, "");
        if (itemPriceStr[0] == "$") itemPriceStr = itemPriceStr.replace("$", "").replace(/,/g, "");
        const itemPrice = parseFloat(itemPriceStr);
        const inputValue = document.querySelectorAll("#quantity__input")[index];
        const itemTotal = document.querySelectorAll("#cart-item__total")[index];
        let val = parseInt(inputValue.value);

        if (val < inputValue.max) {
            val++;
            inputValue.setAttribute("value", val);
            let itemTotalPrice = val * itemPrice;
            itemTotal.innerHTML = formatter.format(itemTotalPrice);
            cartTotalCount++;
            cartTotalPrice += itemPrice;
            totalCountElement.innerHTML = cartTotalCount;
            totalPriceElement.innerHTML = formatter.format(cartTotalPrice);
        }
    })
);

minusBtns.forEach((el, index) =>
    el.addEventListener("click", () => {
        let itemPriceStr = document.querySelectorAll("#cart-item__price")[index].innerHTML.replace(/&nbsp;/g, "");
        if (itemPriceStr[0] == "$") itemPriceStr = itemPriceStr.replace("$", "").replace(/,/g, "");
        const itemPrice = parseFloat(itemPriceStr);
        const inputValue = document.querySelectorAll(".quantity__input")[index];
        const itemTotal = document.querySelectorAll("#cart-item__total")[index];
        let val = parseInt(inputValue.value);

        if (val > 1) {
            val--;
            inputValue.setAttribute("value", val);
            itemTotal.innerHTML = formatter.format(val * itemPrice);
            cartTotalCount--;
            totalCountElement.innerHTML = cartTotalCount;
            cartTotalPrice -= itemPrice;
            totalPriceElement.innerHTML = formatter.format(cartTotalPrice);
        }
    })
);