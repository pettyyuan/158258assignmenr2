document.querySelectorAll('a').forEach(function(el){
    el.addEventListener('click', function(){
        var dHeight = document.documentElement.clientHeight;
        var target = document.querySelector('div[data-tab=' + this.getAttribute('data-tab')+ ']' )
        target.height = (dHeight - 70) + "px";
        target.scrollIntoView({behavior:"smooth"});
    //布尔参数
    })
})