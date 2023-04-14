function deleteZaposleni(id) {
    if (confirm("Da li ste sigurni?")) {
        let url = `${window.location.protocol}//${window.location.host}/Zaposleni/DeleteZaposleni/${id}`;
        window.location.href = url;
    }
}