function CreateEventForm(dayNumber, dayName) {
    this._BACKGROUND =
        '<div class="formbackground">' +
        '</div>';

    this._TEMPLATE =
        '<div class="formEvent">' +
        '    <div class="formHeader">' + 'Добавить событие' + '</div>' +
        '    <div class="formBody">' +
        '        <form>' +
        '            <div class="formBody formTextEvent" data-name="dayName"> ' + 'День недели' +
        '                <label>' + '' +
        '                    <input name="dayName"  type="text" value="" readonly>' +
        '                </label>' +
        '            </div>' +
        '            <div class="formBody formTextEvent" data-name="dayNumber"> ' + 'Число' +
        '                <label>' + '' +
        '                    <input name="dayNumber"  type="text" value="" readonly>' +
        '                </label>' +
        '            </div>' +
        '            <div class="formBody formTextEvent" data-name="name"> ' + 'Событие' +
        '                <label>' + '' +
        '                    <input name="name" type="text" value="">' +
        '                </label>' +
        '            </div>' +
        '            <div class="formButton"> ' +
        '                <input type="submit" value="' + 'Добавить событие' + '" />' +
        '            </div>' +
        '        </form>' +
        '    </div>' +
        '</div>';

    this.show = function () {
        var def = $.Deferred();
        document.body.insertAdjacentHTML('beforeEnd', this._BACKGROUND);
        var element = document.body.querySelector(".formbackground")
        element.insertAdjacentHTML('beforeEnd', this._TEMPLATE);
        this.getElement("dayNumber").querySelector("input").value = dayNumber;
        this.getElement("dayName").querySelector("input").value = dayName;
        var form = element.querySelector("form");
        form.addEventListener("submit", (function (event) {
            event.preventDefault();
            this.createEvent({
                name: this.getElement("name").querySelector("input").value,
            }).done((function () {
                def.resolve(true);
            }).bind(this));
        }).bind(this));
    };

    this.getElement = function (fieldName) {
        return document.body.querySelector(".formEvent .formBody[data-name ='" + fieldName + "']");
    }

    this.createEvent = function (info) {
        var def = $.Deferred();
        $.ajax({
            url: "/Event/Create",
            type: "post",
            data: {
                DayName: dayName,
                DayNumber: dayNumber,
                MonthNumber: 1,
                UserInfo: '',
                EventText: info.name
            },
            success: function () {
                location.replace('calendar');
            }
        });
        return def.promise();
    }
}