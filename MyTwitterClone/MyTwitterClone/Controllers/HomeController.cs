using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTwitterClone.Business.Interface;
using MyTwitterClone.Entity;
namespace MyTwitterClone.Controllers
{
    public class HomeController : Controller
    {
        ITwitterClone _ITwitterClone;
        public HomeController(ITwitterClone ITwitterClone)
        {
            _ITwitterClone = ITwitterClone;
        }
        public ActionResult Index()
        {
            ViewBag.IsAuthenticated = true;
            PersonEntity person = new PersonEntity();
            person.user_id = Session["UserName"].ToString();
            FollowingEntity follower = new FollowingEntity();
            follower.user_id = Session["UserName"].ToString();
            ViewBag.FollwerCount= _ITwitterClone.GetFollowerDetails(follower).Count.ToString();
            ViewBag.FollwingCount = _ITwitterClone.GetFollowingDetails(follower).Count.ToString();
            var tweets = _ITwitterClone.GetTweetsDetails(person);
            ViewData["TweetData"] = tweets;
            ViewBag.TweetsCount = tweets.Count.ToString();
            return View();
        }

        public ActionResult UserProfile()
        {
            PersonEntity personEntity = _ITwitterClone.GetUserDetails().Where(x=>x.user_id== Session["UserName"].ToString()).ToList()[0];
            ViewBag.IsAuthenticated = true;
            return View(personEntity);
        }
        public ActionResult Partial_GetTweetsDetails()
        {
            PersonEntity person = new PersonEntity();
            person.user_id = Session["UserName"].ToString();
            var tweets = _ITwitterClone.GetTweetsDetails(person);
            ViewData["TweetData"] = tweets;
            return PartialView(tweets);
        }
        public ActionResult Partial_GetFollowerTweetsDetails()
        {
            PersonEntity person = new PersonEntity();
            person.user_id = Session["UserName"].ToString();
            var tweets = _ITwitterClone.GetFollowerTweetDtls(person);
            ViewData["FolllwerTweetData"] = tweets;
            return PartialView(tweets);
        }
        public ActionResult Partial_GetFollowingTweetsDetails()
        {
            PersonEntity person = new PersonEntity();
            person.user_id = Session["UserName"].ToString();
            var tweets = _ITwitterClone.GetFollowingTweetDtls(person);
            ViewData["FolllwingTweetData"] = tweets;
            return PartialView(tweets);
        }
        [HttpPost]
        public JsonResult AddTweet(TweetEntity personTweets)
        {
            personTweets.created = DateTime.Now;
            personTweets.user_id= Session["UserName"].ToString();
            var response= _ITwitterClone.AddTweet(personTweets);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddFollower(FollowingEntity follower)
        {
            follower.user_id = Session["UserName"].ToString();
            var response = _ITwitterClone.AddFollower(follower);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteTweet(TweetEntity personTweets)
        {
            personTweets.user_id = Session["UserName"].ToString();
            var response = _ITwitterClone.DeleteTweet(personTweets);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}