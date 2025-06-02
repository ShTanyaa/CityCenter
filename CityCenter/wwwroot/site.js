window.mapRent = {
    setupClickHandler: function (dotNetHelper) {
        console.log("⚙️ mapRent.setupClickHandler вызван");
        document.querySelectorAll('g[id^="Store-"] g').forEach(icon => {
            icon.style.display = 'none';
        });


        document.addEventListener('click', function (event) {
            console.log("🖱 document click");

            // Поднимаемся по дереву, чтобы найти ближайший элемент, чей ID начинается с Store-
            const target = event.target.closest('[id^="Store-"]');

            if (!target) return;

            const id = target.id;
            console.log("✅ Clicked on element with ID:", id);

            dotNetHelper.invokeMethodAsync('SetSelectedRoom', id);

            // Вызов анимации выделения (если нужно)
            highlightSelected(id);
        });
    }
};

// 👇 Простой способ выделить прямоугольник
function highlightSelected(id) {
    // Удаляем прошлое выделение
    document.querySelectorAll('g[id^="Store-"]').forEach(el => el.classList.remove('selected'));

    // Добавляем класс выбранному элементу
    const selected = document.querySelector(`g[id="${id}"]`);
    if (selected) selected.classList.add('selected');
}

