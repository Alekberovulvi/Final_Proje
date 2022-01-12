var openModals = document.querySelectorAll('.openModal');
  openModals.forEach(openModal=>{
    openModal.addEventListener('click',function(e){
        e.preventDefault();
        let url = openModal.getAttribute('href');
        document.querySelector('.modal-container').style.display = 'block';
        fetch(url).then(response => response.text()).then(data => {
            document.querySelector('.modal-container').innerHTML = data;
            let plus = document.querySelector('.controls .plus');
            let minus = document.querySelector('.controls .minus');
            let price = document.querySelector('.controls .price').innerText.slice(0, -1);
            plus.addEventListener('click', function () {
                let count = document.querySelector('.controls .count').innerText;
                this.parentElement.querySelector('.price').innerText = ++count * +price + '₼';
                document.querySelector('.controls .count').innerText = count;
                let url = document.querySelector('.add-basket').getAttribute('href');
                let urlPart = url.slice(url.indexOf('count='), url.indexOf('count=') + 7);
                url = url.replace(urlPart, `count=${count}`);
                document.querySelector('.add-basket').setAttribute('href', url);
            });

            minus.addEventListener('click', function () {
                let count = document.querySelector('.controls .count').innerText;
                if (count > 1) {

                    document.querySelector('.controls .count').innerText = --count;
                    this.parentElement.querySelector('.price').innerText = count * +price + '₼';
                    let url = document.querySelector('.add-basket').getAttribute('href');
                    let urlPart = url.slice(url.indexOf('count='), url.indexOf('count=') + 7);
                    url = url.replace(urlPart, `count=${count}`);
                    document.querySelector('.add-basket').setAttribute('href', url);
                }
            });
            let closeModal = document.querySelector('.modal-container .close');

            closeModal.addEventListener('click', function () {
                document.querySelector('.modal-container').style.display = 'none';
            })
        })
    });
  });



