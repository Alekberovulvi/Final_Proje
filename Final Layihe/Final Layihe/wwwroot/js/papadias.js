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

            plus.addEventListener('click', function () {
                let count = document.querySelector('.controls .count').innerText;
                document.querySelector('.controls .count').innerText = ++count;
            });

            minus.addEventListener('click', function () {
                let count = document.querySelector('.controls .count').innerText;
                if (count >= 1) {
                    document.querySelector('.controls .count').innerText = --count;
                }
            });
            let closeModal = document.querySelector('.modal-container .close');

            closeModal.addEventListener('click', function () {
                document.querySelector('.modal-container').style.display = 'none';
            })
        })
    });
  });



