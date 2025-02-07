
    function filterDigits(event) {
        event.target.value = event.target.value.replace(/\D/g, ''); // Оставляем только цифры
    }

    function filterPassport(event) {
        event.target.value = event.target.value.replace(/[^0-9 ]/g, '').replace(/(\d{4})(\d{6})/, '$1 $2'); // Формат '1234 567890'
    }

    function filterPhone(event) {
        event.target.value = event.target.value.replace(/[^0-9+]/g, ''); // Цифры и '+'
    }

