client.test("Получить Сущность По Номеру Заявки и Типу Заявки (не валидная)", function() {
    var result = response.body["result"];
    var model = response.body["model"];

    client.assert(response.status === 200,
        "Response status должен быть 200, а на самом деле: "
        + response.status.toString());

    client.assert(result.code === 500,
        "result.code должен быть 500, а пришел result.code=" + result.code + "\r\n" + result["msg"]);
});
