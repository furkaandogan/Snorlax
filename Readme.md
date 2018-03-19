# Snorlax

### Demo Hesap Bilgileri
email: admin@snorlax.com

şifre: admin

## Proje Hakkında

Proje üç farklı ufak projelerden den oluşmaktadır.

* Api : netcore ile yazılmış ana işlemlerimizi gerçekleştiren apidi. authentication için JWT protokölünü kullanmaktadır. 
* CDN : php ile resim upload ve sunumu için yazılmıştır.
* UI :  react + redux kullanılarak geliştirilmiştir. kullanıcıdan alınan dataları apilere gönderir

proje dockerize edilmeye uygun şekilde yazılmıştır. Her bir proje içerinden kendi image larını oluşturacak dockerfile dosyaları bulunmaktadır.

Docker Compose yada Swarm(cluster) için ise docker klasörü altında docker-compose.yml ve env dosyaları bulunmaktadır.

api ve cdn istek linkleri aşağıdaki postman collectionında bulunmaktadır.

[![Run in Postman](https://run.pstmn.io/button.svg)](https://www.getpostman.com/collections/28a3cb8030e741e5ddc1)

## Proje çalıştırası

Proje github dan çekildikten sonra 

Api:
```
$ cd Desktop/Snorlax/srx/Snorlax.Web.Api
$ dotnet restore
$ dotnet build
$ cd dotnet /bin/Debug/netcoreapp2.0/Snorlax.Web.Api.dll or F5
```
UI
```
$ cd Desktop/Snorlax/srx/Snorlax.Web.UI
$ npm install
$ npm start
```

## Kullanılan teknolojiler ve kütüphanelerin bazıları

* [NetCore](https://www.microsoft.com/net/learn/get-started/windows) 
* [Php](http://php.net/docs.php) 
* [React](https://reactjs.org/)
* [Redux](https://redux.js.org/) 
* [Webpack](https://webpack.js.org/) 
* [MongoDB](https://www.mongodb.com/) 
* [MSSQLServer](https://www.microsoft.com/tr-tr/sql-server/sql-server-2016) 
* [FluentValidation](https://github.com/JeremySkinner/FluentValidation) 
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) 
* [MongoDb.Driver](https://www.nuget.org/packages/MongoDB.Driver/)
* [ex-js-linq](https://www.npmjs.com/package/ex-js-linq#foreach)
* [Nodejs](https://nodejs.org/en/)
* [npm](https://www.npmjs.com/)
* [axios](https://github.com/axios/axios)
* [Promise](https://www.promisejs.org/)
* [Docker + Swarm + Compose](https://docker.com)
* [Makefile](https://en.wikipedia.org/wiki/Makefile)
