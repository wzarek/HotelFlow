const { createProxyMiddleware } = require('http-proxy-middleware');
const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:7294';

const context =  [
  "/api/users",
  "/api/users/all",
  "/api/users/getwithoffset",
  "/api/users/getuserbyid",
  "/api/users/getbyroleid",
  "/api/users/edit",
  "/api/users/editmultiple",
  "/api/users/delete",
  "/api/users/editmultiplebyids",
  "/api/users/getcurrentuserinfo",
  "/api/users/editcurrentuser",

  "/api/reservations",
  "/api/reservations/all",
  "/api/reservations/getreservationbyid",
  "/api/reservations/getwithoffset",
  "/api/reservations/edit",
  "/api/reservations/editstatus",
  "/api/reservations/add",
  "/api/reservations/getreservationforreview",
  "/api/reservations/getcurrentuserreservations",

  "/api/reviews",
  "/api/reviews/all",
  "/api/reviews/getwithoffset",
  "/api/reviews/getreviewforreservation",
  "/api/reviews/add",
  "/api/reviews/delete",

  "/api/rooms",
  "/api/rooms/all",
  "/api/rooms/random",
  "/api/rooms/allwithinactive",
  "/api/rooms/getwithoffset",
  "/api/rooms/getroombyid",
  "/api/rooms/getbystatus",
  "/api/rooms/getbytypes",
  "/api/rooms/edit",
  "/api/rooms/editmultiple",
  "/api/rooms/delete",
  "/api/rooms/deletemultiplebyids",
  "/api/rooms/add",
  "/api/rooms/addmultiple",

  "/api/visuals",
  "/api/visuals/allfloors",
  "/api/visuals/getfloorbyid",
  "/api/visuals/addfloor",
  "/api/visuals/editfloor",
  "/api/visuals/deletefloor",
  "/api/visuals/editobjectplacement",
  "/api/visuals/deleteobjectplacement",
  '/api/visuals/addobjectplacement',

  "/api/cleaning/",
  "/api/cleaning/all",
  "/api/cleaning/getcleaningscheduleforemployee",
  "/api/cleaning/add",
  "/api/cleaning/edit",
  "/aapi/cleaning/delete",

  "/api/login",
  "/api/register"
];

module.exports = function(app) {
  const appProxy = createProxyMiddleware(context, {
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  });

  app.use(appProxy);
};
