export function displayTotalPrice(TotalPrice) {
    const calculateButton = document.querySelector('#calculate');
    const totalDisplay = document.querySelector('#total');

    calculateButton.addEventListener('click', function () {
        const prices = document.querySelectorAll('.price');
        let total = 0;
        prices.forEach(function (price) {
            total += parseFloat(price.textContent);
        });
        totalDisplay.textContent = 'Total: $' + total;
    });
}