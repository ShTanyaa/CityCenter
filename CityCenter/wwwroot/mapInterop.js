// mapInterop.js
window.mapInterop = {
    // Инициализация всех обработчиков
    initialize: function (dotNetHelper) {
        this.setupSearch();
        this.setupMapClickHandler(dotNetHelper);
        this.setupScrollHandlers();
    },

    // Настройка поиска
    setupSearch: function () {
        const searchPanel = document.getElementById('search-panel');
        const searchInput = document.getElementById('search-input');

        if (!searchPanel || !searchInput) return;

        // Обработчик переключения панели поиска
        window.toggleSearchPanel = function () {
            searchPanel.classList.toggle('hidden');
            if (!searchPanel.classList.contains('hidden')) {
                searchInput.focus();
            }
        };

        // Обработчик нажатия Enter
        searchInput.onkeydown = function (event) {
            if (event.key === 'Enter') {
                const query = searchInput.value.trim();
                if (query) {
                   // В mapInterop.js
performSearch: function(query) {
    // Реальная логика поиска вместо alert
    console.log("Searching for:", query);
    // Можно добавить вызов .NET метода через dotNetHelper
}
                }
            }
        };
    },

    // Обработчики кликов по карте
    setupMapClickHandler: function (dotNetHelper) {
        document.addEventListener('click', function (event) {
            // Закрытие панели поиска при клике вне её
            const searchPanel = document.getElementById('search-panel');
            if (searchPanel && !searchPanel.contains(event.target) &&
                !event.target.closest('.sidebar')) {
                searchPanel.classList.add('hidden');
            }

            // Обработка кликов по помещениям
            const target = event.target.closest('[id^="Store-"]');
            if (target) {
                dotNetHelper.invokeMethodAsync('SetSelectedRoom', target.id);
                highlightSelected(target.id);
            }
        });
    },

    // Прокрутка к карте
    setupScrollHandlers: function () {
        window.scrollToMap = function () {
            const map = document.getElementById('mall-map');
            if (map) {
                map.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        };
    }
};

// Вспомогательная функция выделения
function highlightSelected(id) {
    document.querySelectorAll('[id^="Store-"]').forEach(el =>
        el.classList.remove('selected'));
    const selected = document.getElementById(id);
    if (selected) selected.classList.add('selected');
}