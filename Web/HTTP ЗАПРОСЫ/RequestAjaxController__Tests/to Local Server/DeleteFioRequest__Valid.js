client.test("Заявка на удаление ФИО (валидная)", function() {
    var result = response.body["result"];
    var model = response.body["model"];

    client.assert(response.status === 200, "Response status должен быть 200, а на самом деле: " + response.status.toString());

    client.assert(result.code === 200,
        "Код результата должен быть 200, а пришел код=" + result.code + "\r\n" + result.msg);
});
