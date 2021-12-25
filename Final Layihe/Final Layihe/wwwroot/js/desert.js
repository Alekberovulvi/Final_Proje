  let openModals = document.querySelectorAll('.openModal');
  let closeModals = document.querySelectorAll('.modal-container .close');

  openModals.forEach(openModal=>{
      openModal.addEventListener('click', function (e) {
          let url = openModal.getAttribute('href');
          console.log(url)
      e.preventDefault();
      document.querySelector('.modal-container').style.display = 'block';
    });
  });

  closeModals.forEach(closeModal=>{
    closeModal.addEventListener('click',function(){
      document.querySelector('.modal-container').style.display = 'none';
    })
  });


  let plus = document.querySelector('.controls .plus');
  let minus = document.querySelector('.controls .minus');

  plus.addEventListener('click',function(){
    let count = document.querySelector('.controls .count').innerText;
    document.querySelector('.controls .count').innerText= ++count;
  });

  minus.addEventListener('click',function(){
    let count = document.querySelector('.controls .count').innerText;
    if(count>=1){
      document.querySelector('.controls .count').innerText= --count;
    }
  });