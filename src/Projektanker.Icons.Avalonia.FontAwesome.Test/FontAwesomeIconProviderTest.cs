using System;
using System.Collections.Generic;
using FluentAssertions;
using SkiaSharp;
using Xunit;

namespace Projektanker.Icons.Avalonia.FontAwesome.Test
{
    public class FontAwesomeIconProviderTest
    {
        private readonly IIconProvider _iconProvider = new FontAwesomeIconProvider();

        [Theory]
        [InlineData("fa-github")]
        [InlineData("fa-arrow-left")]
        [InlineData("fa-arrow-right")]
        [InlineData("fa-brands fa-github")]
        [InlineData("fa-solid fa-arrow-left")]
        [InlineData("fa-regular fa-address-book")]
        public void Icon_Should_Exist_And_Be_Valid_SVG_Path(string value)
        {
            // Act #1
            var path = _iconProvider.GetIconPath(value);

            // Assert #1
            path.Should().NotBeNullOrEmpty();

            // Act #2
            var skiaPath = SKPath.ParseSvgPathData(path);

            // Assert #2
            skiaPath.Should().NotBeNull();
            skiaPath.Bounds.IsEmpty.Should().BeFalse();
        }

        [Theory]
        [InlineData("fa-you-cant-find-me")]
        [InlineData("fa")]
        [InlineData("far fa-arrow-left")]
        public void IconProvider_Should_Throw_Exception_If_Icon_Does_Not_Exist(string value)
        {
            // Act
            Func<string> func = () => _iconProvider.GetIconPath(value);

            // Assert
            func.Should().Throw<KeyNotFoundException>();
        }

        [Theory]
        [InlineData("fab fa-github", "fa-brands fa-github")]
        [InlineData("fas fa-arrow-left", "fa-solid fa-arrow-left")]
        [InlineData("far fa-address-book", "fa-regular fa-address-book")]
        public void Legacy_Style_Should_Still_Work(string legacy, string version6)
        {
            // Act
            var legacyPath = _iconProvider.GetIconPath(legacy);
            var version6Path = _iconProvider.GetIconPath(version6);

            // Assert
            legacyPath.Should().Be(version6Path);
        }

        [Theory]
        [InlineData("ad", "rectangle-ad")]
        [InlineData("adjust", "circle-half-stroke")]
        [InlineData("air-freshener", "spray-can-sparkles")]
        [InlineData("allergies", "hand-dots")]
        [InlineData("ambulance", "truck-medical")]
        [InlineData("american-sign-language-interpreting", "hands-asl-interpreting")]
        [InlineData("angle-double-down", "angles-down")]
        [InlineData("angle-double-left", "angles-left")]
        [InlineData("angle-double-right", "angles-right")]
        [InlineData("angle-double-up", "angles-up")]
        [InlineData("angry", "face-angry")]
        [InlineData("apple-alt", "apple-whole")]
        [InlineData("archive", "box-archive")]
        [InlineData("arrow-alt-circle-down", "circle-down")]
        [InlineData("arrow-alt-circle-left", "circle-left")]
        [InlineData("arrow-alt-circle-right", "circle-right")]
        [InlineData("arrow-alt-circle-up", "circle-up")]
        [InlineData("arrow-circle-down", "circle-arrow-down")]
        [InlineData("arrow-circle-left", "circle-arrow-left")]
        [InlineData("arrow-circle-right", "circle-arrow-right")]
        [InlineData("arrow-circle-up", "circle-arrow-up")]
        [InlineData("arrows", "arrows-up-down-left-right")]
        [InlineData("arrows-alt", "up-down-left-right")]
        [InlineData("arrows-alt-h", "left-right")]
        [InlineData("arrows-alt-v", "up-down")]
        [InlineData("arrows-h", "arrows-left-right")]
        [InlineData("arrows-v", "arrows-up-down")]
        [InlineData("assistive-listening-systems", "ear-listen")]
        [InlineData("atlas", "book-atlas")]
        [InlineData("backspace", "delete-left")]
        [InlineData("balance-scale", "scale-balanced")]
        [InlineData("balance-scale-left", "scale-unbalanced")]
        [InlineData("balance-scale-right", "scale-unbalanced-flip")]
        [InlineData("band-aid", "bandage")]
        [InlineData("baseball-ball", "baseball")]
        [InlineData("basketball-ball", "basketball")]
        [InlineData("beer", "beer-mug-empty")]
        [InlineData("bible", "book-bible")]
        [InlineData("biking", "person-biking")]
        [InlineData("birthday-cake", "cake-candles")]
        [InlineData("blind", "person-walking-with-cane")]
        [InlineData("book-dead", "book-skull")]
        [InlineData("book-reader", "book-open-reader")]
        [InlineData("border-style", "border-top-left")]
        [InlineData("boxes", "boxes-stacked")]
        [InlineData("boxes-alt", "boxes-stacked")]
        [InlineData("broadcast-tower", "tower-broadcast")]
        [InlineData("burn", "fire-flame-simple")]
        [InlineData("bus-alt", "bus-simple")]
        [InlineData("calendar-alt", "calendar-days")]
        [InlineData("calendar-times", "calendar-xmark")]
        [InlineData("camera-alt", "camera")]
        [InlineData("car-alt", "car-rear")]
        [InlineData("caret-square-down", "square-caret-down")]
        [InlineData("caret-square-left", "square-caret-left")]
        [InlineData("caret-square-right", "square-caret-right")]
        [InlineData("caret-square-up", "square-caret-up")]
        [InlineData("chalkboard-teacher", "chalkboard-user")]
        [InlineData("check-circle", "circle-check")]
        [InlineData("check-square", "square-check")]
        [InlineData("chevron-circle-down", "circle-chevron-down")]
        [InlineData("chevron-circle-left", "circle-chevron-left")]
        [InlineData("chevron-circle-right", "circle-chevron-right")]
        [InlineData("chevron-circle-up", "circle-chevron-up")]
        [InlineData("clinic-medical", "house-chimney-medical")]
        [InlineData("cloud-download", "cloud-arrow-down")]
        [InlineData("cloud-download-alt", "cloud-arrow-down")]
        [InlineData("cloud-upload", "cloud-arrow-up")]
        [InlineData("cloud-upload-alt", "cloud-arrow-up")]
        [InlineData("cocktail", "martini-glass-citrus")]
        [InlineData("coffee", "mug-saucer")]
        [InlineData("cog", "gear")]
        [InlineData("cogs", "gears")]
        [InlineData("columns", "table-columns")]
        [InlineData("comment-alt", "message")]
        [InlineData("compress-alt", "down-left-and-up-right-to-center")]
        [InlineData("compress-arrows-alt", "minimize")]
        [InlineData("concierge-bell", "bell-concierge")]
        [InlineData("crop-alt", "crop-simple")]
        [InlineData("cut", "scissors")]
        [InlineData("deaf", "ear-deaf")]
        [InlineData("desktop-alt", "desktop")]
        [InlineData("diagnoses", "person-dots-from-line")]
        [InlineData("digging", "person-digging")]
        [InlineData("digital-tachograph", "tachograph-digital")]
        [InlineData("directions", "diamond-turn-right")]
        [InlineData("dizzy", "face-dizzy")]
        [InlineData("dolly-flatbed", "cart-flatbed")]
        [InlineData("donate", "circle-dollar-to-slot")]
        [InlineData("dot-circle", "circle-dot")]
        [InlineData("drafting-compass", "compass-drafting")]
        [InlineData("edit", "pen-to-square")]
        [InlineData("ellipsis-h", "ellipsis")]
        [InlineData("ellipsis-v", "ellipsis-vertical")]
        [InlineData("envelope-square", "square-envelope")]
        [InlineData("exchange", "arrow-right-arrow-left")]
        [InlineData("exchange-alt", "right-left")]
        [InlineData("exclamation-circle", "circle-exclamation")]
        [InlineData("exclamation-triangle", "triangle-exclamation")]
        [InlineData("expand-alt", "up-right-and-down-left-from-center")]
        [InlineData("expand-arrows-alt", "maximize")]
        [InlineData("external-link", "arrow-up-right-from-square")]
        [InlineData("external-link-alt", "up-right-from-square")]
        [InlineData("external-link-square", "square-arrow-up-right")]
        [InlineData("external-link-square-alt", "square-up-right")]
        [InlineData("fast-backward", "backward-fast")]
        [InlineData("fast-forward", "forward-fast")]
        [InlineData("feather-alt", "feather-pointed")]
        [InlineData("female", "person-dress")]
        [InlineData("fighter-jet", "jet-fighter")]
        [InlineData("file-alt", "file-lines")]
        [InlineData("file-archive", "file-zipper")]
        [InlineData("file-download", "file-arrow-down")]
        [InlineData("file-edit", "file-pen")]
        [InlineData("file-medical-alt", "file-waveform")]
        [InlineData("file-upload", "file-arrow-up")]
        [InlineData("fire-alt", "fire-flame-curved")]
        [InlineData("first-aid", "kit-medical")]
        [InlineData("fist-raised", "hand-fist")]
        [InlineData("flushed", "face-flushed")]
        [InlineData("font-awesome-alt", "square-font-awesome-stroke")]
        [InlineData("font-awesome-flag", "font-awesome")]
        [InlineData("font-awesome-logo-full", "font-awesome")]
        [InlineData("football-ball", "football")]
        [InlineData("frown", "face-frown")]
        [InlineData("frown-open", "face-frown-open")]
        [InlineData("funnel-dollar", "filter-circle-dollar")]
        [InlineData("glass-cheers", "champagne-glasses")]
        [InlineData("glass-martini", "martini-glass-empty")]
        [InlineData("glass-martini-alt", "martini-glass")]
        [InlineData("glass-whiskey", "whiskey-glass")]
        [InlineData("globe-africa", "earth-africa")]
        [InlineData("globe-americas", "earth-americas")]
        [InlineData("globe-asia", "earth-asia")]
        [InlineData("globe-europe", "earth-europe")]
        [InlineData("golf-ball", "golf-ball-tee")]
        [InlineData("grimace", "face-grimace")]
        [InlineData("grin", "face-grin")]
        [InlineData("grin-alt", "face-grin-wide")]
        [InlineData("grin-beam", "face-grin-beam")]
        [InlineData("grin-beam-sweat", "face-grin-beam-sweat")]
        [InlineData("grin-hearts", "face-grin-hearts")]
        [InlineData("grin-squint", "face-grin-squint")]
        [InlineData("grin-squint-tears", "face-grin-squint-tears")]
        [InlineData("grin-stars", "face-grin-stars")]
        [InlineData("grin-tears", "face-grin-tears")]
        [InlineData("grin-tongue", "face-grin-tongue")]
        [InlineData("grin-tongue-squint", "face-grin-tongue-squint")]
        [InlineData("grin-tongue-wink", "face-grin-tongue-wink")]
        [InlineData("grin-wink", "face-grin-wink")]
        [InlineData("grip-horizontal", "grip")]
        [InlineData("h-square", "square-h")]
        [InlineData("hamburger", "burger")]
        [InlineData("hand-holding-usd", "hand-holding-dollar")]
        [InlineData("hand-holding-water", "hand-holding-droplet")]
        [InlineData("hand-paper", "hand")]
        [InlineData("hand-rock", "hand-back-fist")]
        [InlineData("hands-helping", "handshake-angle")]
        [InlineData("hands-wash", "hands-bubbles")]
        [InlineData("handshake-alt", "handshake-simple")]
        [InlineData("handshake-alt-slash", "handshake-simple-slash")]
        [InlineData("hard-hat", "helmet-safety")]
        [InlineData("hdd", "hard-drive")]
        [InlineData("headphones-alt", "headphones-simple")]
        [InlineData("heart-broken", "heart-crack")]
        [InlineData("heartbeat", "heart-pulse")]
        [InlineData("hiking", "person-hiking")]
        [InlineData("history", "clock-rotate-left")]
        [InlineData("home", "house")]
        [InlineData("home-alt", "house")]
        [InlineData("home-lg", "house-chimney")]
        [InlineData("home-lg-alt", "house")]
        [InlineData("hospital-alt", "hospital")]
        [InlineData("hospital-symbol", "circle-h")]
        [InlineData("hot-tub", "hot-tub-person")]
        [InlineData("hourglass-half", "hourglass")]
        [InlineData("house-damage", "house-chimney-crack")]
        [InlineData("hryvnia", "hryvnia-sign")]
        [InlineData("id-card-alt", "id-card-clip")]
        [InlineData("info-circle", "circle-info")]
        [InlineData("innosoft", "42-group")]
        [InlineData("journal-whills", "book-journal-whills")]
        [InlineData("kiss", "face-kiss")]
        [InlineData("kiss-beam", "face-kiss-beam")]
        [InlineData("kiss-wink-heart", "face-kiss-wink-heart")]
        [InlineData("landmark-alt", "landmark-dome")]
        [InlineData("laptop-house", "house-laptop")]
        [InlineData("laugh", "face-laugh")]
        [InlineData("laugh-beam", "face-laugh-beam")]
        [InlineData("laugh-squint", "face-laugh-squint")]
        [InlineData("laugh-wink", "face-laugh-wink")]
        [InlineData("level-down", "arrow-turn-down")]
        [InlineData("level-down-alt", "turn-down")]
        [InlineData("level-up", "arrow-turn-up")]
        [InlineData("level-up-alt", "turn-up")]
        [InlineData("list-alt", "rectangle-list")]
        [InlineData("location", "location-crosshairs")]
        [InlineData("long-arrow-alt-down", "down-long")]
        [InlineData("long-arrow-alt-left", "left-long")]
        [InlineData("long-arrow-alt-right", "right-long")]
        [InlineData("long-arrow-alt-up", "up-long")]
        [InlineData("long-arrow-down", "arrow-down-long")]
        [InlineData("long-arrow-left", "arrow-left-long")]
        [InlineData("long-arrow-right", "arrow-right-long")]
        [InlineData("long-arrow-up", "arrow-up-long")]
        [InlineData("low-vision", "eye-low-vision")]
        [InlineData("luggage-cart", "cart-flatbed-suitcase")]
        [InlineData("magic", "wand-magic")]
        [InlineData("mail-bulk", "envelopes-bulk")]
        [InlineData("male", "person")]
        [InlineData("map-marked", "map-location")]
        [InlineData("map-marked-alt", "map-location-dot")]
        [InlineData("map-marker", "location-pin")]
        [InlineData("map-marker-alt", "location-dot")]
        [InlineData("map-signs", "signs-post")]
        [InlineData("mars-stroke-h", "mars-stroke-right")]
        [InlineData("mars-stroke-v", "mars-stroke-up")]
        [InlineData("medium-m", "medium")]
        [InlineData("medkit", "suitcase-medical")]
        [InlineData("meh", "face-meh")]
        [InlineData("meh-blank", "face-meh-blank")]
        [InlineData("meh-rolling-eyes", "face-rolling-eyes")]
        [InlineData("microphone-alt", "microphone-lines")]
        [InlineData("microphone-alt-slash", "microphone-lines-slash")]
        [InlineData("minus-circle", "circle-minus")]
        [InlineData("minus-square", "square-minus")]
        [InlineData("mobile-alt", "mobile-screen-button")]
        [InlineData("mobile-android", "mobile")]
        [InlineData("mobile-android-alt", "mobile-screen")]
        [InlineData("money-bill-alt", "money-bill-1")]
        [InlineData("money-bill-wave-alt", "money-bill-1-wave")]
        [InlineData("money-check-alt", "money-check-dollar")]
        [InlineData("mouse", "computer-mouse")]
        [InlineData("mouse-pointer", "arrow-pointer")]
        [InlineData("paint-brush", "paintbrush")]
        [InlineData("parking", "square-parking")]
        [InlineData("pastafarianism", "spaghetti-monster-flying")]
        [InlineData("pause-circle", "circle-pause")]
        [InlineData("pen-alt", "pen-clip")]
        [InlineData("pen-square", "square-pen")]
        [InlineData("pencil-alt", "pencil")]
        [InlineData("pencil-ruler", "pen-ruler")]
        [InlineData("percentage", "percent")]
        [InlineData("phone-alt", "phone-flip")]
        [InlineData("phone-square", "square-phone")]
        [InlineData("phone-square-alt", "square-phone-flip")]
        [InlineData("photo-video", "photo-film")]
        [InlineData("play-circle", "circle-play")]
        [InlineData("plus-circle", "circle-plus")]
        [InlineData("plus-square", "square-plus")]
        [InlineData("poll", "square-poll-vertical")]
        [InlineData("poll-h", "square-poll-horizontal")]
        [InlineData("portrait", "image-portrait")]
        [InlineData("pound-sign", "sterling-sign")]
        [InlineData("pray", "person-praying")]
        [InlineData("praying-hands", "hands-praying")]
        [InlineData("prescription-bottle-alt", "prescription-bottle-medical")]
        [InlineData("procedures", "bed-pulse")]
        [InlineData("project-diagram", "diagram-project")]
        [InlineData("question-circle", "circle-question")]
        [InlineData("quran", "book-quran")]
        [InlineData("radiation-alt", "circle-radiation")]
        [InlineData("random", "shuffle")]
        [InlineData("redo", "arrow-rotate-right")]
        [InlineData("redo-alt", "rotate-right")]
        [InlineData("remove-format", "text-slash")]
        [InlineData("rss-square", "square-rss")]
        [InlineData("running", "person-running")]
        [InlineData("sad-cry", "face-sad-cry")]
        [InlineData("sad-tear", "face-sad-tear")]
        [InlineData("save", "floppy-disk")]
        [InlineData("search", "magnifying-glass")]
        [InlineData("search-dollar", "magnifying-glass-dollar")]
        [InlineData("search-location", "magnifying-glass-location")]
        [InlineData("search-minus", "magnifying-glass-minus")]
        [InlineData("search-plus", "magnifying-glass-plus")]
        [InlineData("share-alt", "share-nodes")]
        [InlineData("share-alt-square", "square-share-nodes")]
        [InlineData("share-square", "share-from-square")]
        [InlineData("shipping-fast", "truck-fast")]
        [InlineData("shopping-bag", "bag-shopping")]
        [InlineData("shopping-basket", "basket-shopping")]
        [InlineData("shopping-cart", "cart-shopping")]
        [InlineData("shuttle-van", "van-shuttle")]
        [InlineData("sign", "sign-hanging")]
        [InlineData("sign-in", "arrow-right-to-bracket")]
        [InlineData("sign-in-alt", "right-to-bracket")]
        [InlineData("sign-language", "hands")]
        [InlineData("sign-out", "arrow-right-from-bracket")]
        [InlineData("sign-out-alt", "right-from-bracket")]
        [InlineData("skating", "person-skating")]
        [InlineData("skiing", "person-skiing")]
        [InlineData("skiing-nordic", "person-skiing-nordic")]
        [InlineData("slack-hash", "slack")]
        [InlineData("sliders-h", "sliders")]
        [InlineData("smile", "face-smile")]
        [InlineData("smile-beam", "face-smile-beam")]
        [InlineData("smile-wink", "face-smile-wink")]
        [InlineData("smoking-ban", "ban-smoking")]
        [InlineData("sms", "comment-sms")]
        [InlineData("snapchat-ghost", "snapchat")]
        [InlineData("snowboarding", "person-snowboarding")]
        [InlineData("sort-alpha-down", "arrow-down-a-z")]
        [InlineData("sort-alpha-down-alt", "arrow-down-z-a")]
        [InlineData("sort-alpha-up", "arrow-up-a-z")]
        [InlineData("sort-alpha-up-alt", "arrow-up-z-a")]
        [InlineData("sort-amount-down", "arrow-down-wide-short")]
        [InlineData("sort-amount-down-alt", "arrow-down-short-wide")]
        [InlineData("sort-amount-up", "arrow-up-wide-short")]
        [InlineData("sort-amount-up-alt", "arrow-up-short-wide")]
        [InlineData("sort-numeric-down", "arrow-down-1-9")]
        [InlineData("sort-numeric-down-alt", "arrow-down-9-1")]
        [InlineData("sort-numeric-up", "arrow-up-1-9")]
        [InlineData("sort-numeric-up-alt", "arrow-up-9-1")]
        [InlineData("space-shuttle", "shuttle-space")]
        [InlineData("square-root-alt", "square-root-variable")]
        [InlineData("star-half-alt", "star-half-stroke")]
        [InlineData("step-backward", "backward-step")]
        [InlineData("step-forward", "forward-step")]
        [InlineData("sticky-note", "note-sticky")]
        [InlineData("stop-circle", "circle-stop")]
        [InlineData("store-alt", "shop")]
        [InlineData("store-alt-slash", "shop-slash")]
        [InlineData("stream", "bars-staggered")]
        [InlineData("subway", "train-subway")]
        [InlineData("surprise", "face-surprise")]
        [InlineData("swimmer", "person-swimming")]
        [InlineData("swimming-pool", "water-ladder")]
        [InlineData("sync", "arrows-rotate")]
        [InlineData("sync-alt", "rotate")]
        [InlineData("table-tennis", "table-tennis-paddle-ball")]
        [InlineData("tablet-alt", "tablet-screen-button")]
        [InlineData("tablet-android", "tablet")]
        [InlineData("tachometer", "gauge-simple")]
        [InlineData("tachometer-alt", "gauge")]
        [InlineData("tachometer-alt-fast", "gauge")]
        [InlineData("tasks", "list-check")]
        [InlineData("tasks-alt", "bars-progress")]
        [InlineData("telegram-plane", "telegram")]
        [InlineData("temperature-down", "temperature-arrow-down")]
        [InlineData("temperature-up", "temperature-arrow-up")]
        [InlineData("tenge", "tenge-sign")]
        [InlineData("th", "table-cells")]
        [InlineData("th-large", "table-cells-large")]
        [InlineData("th-list", "table-list")]
        [InlineData("theater-masks", "masks-theater")]
        [InlineData("thermometer-empty", "temperature-empty")]
        [InlineData("thermometer-full", "temperature-full")]
        [InlineData("thermometer-half", "temperature-half")]
        [InlineData("thermometer-quarter", "temperature-quarter")]
        [InlineData("thermometer-three-quarters", "temperature-three-quarters")]
        [InlineData("thunderstorm", "cloud-bolt")]
        [InlineData("ticket-alt", "ticket-simple")]
        [InlineData("times", "xmark")]
        [InlineData("times-circle", "circle-xmark")]
        [InlineData("times-square", "square-xmark")]
        [InlineData("tint", "droplet")]
        [InlineData("tint-slash", "droplet-slash")]
        [InlineData("tired", "face-tired")]
        [InlineData("tools", "screwdriver-wrench")]
        [InlineData("torah", "scroll-torah")]
        [InlineData("tram", "train-tram")]
        [InlineData("transgender-alt", "transgender")]
        [InlineData("trash-alt", "trash-can")]
        [InlineData("trash-restore", "trash-arrow-up")]
        [InlineData("trash-restore-alt", "trash-can-arrow-up")]
        [InlineData("truck-loading", "truck-ramp-box")]
        [InlineData("tshirt", "shirt")]
        [InlineData("tv-alt", "tv")]
        [InlineData("undo", "arrow-rotate-left")]
        [InlineData("undo-alt", "rotate-left")]
        [InlineData("university", "building-columns")]
        [InlineData("unlink", "link-slash")]
        [InlineData("unlock-alt", "unlock-keyhole")]
        [InlineData("user-alt", "user-large")]
        [InlineData("user-alt-slash", "user-large-slash")]
        [InlineData("user-circle", "circle-user")]
        [InlineData("user-cog", "user-gear")]
        [InlineData("user-edit", "user-pen")]
        [InlineData("user-friends", "user-group")]
        [InlineData("user-md", "user-doctor")]
        [InlineData("user-times", "user-xmark")]
        [InlineData("users-cog", "users-gear")]
        [InlineData("utensil-spoon", "spoon")]
        [InlineData("volleyball-ball", "volleyball")]
        [InlineData("volume-down", "volume-low")]
        [InlineData("volume-mute", "volume-xmark")]
        [InlineData("volume-up", "volume-high")]
        [InlineData("vote-yea", "check-to-slot")]
        [InlineData("walking", "person-walking")]
        [InlineData("weight", "weight-scale")]
        [InlineData("window-close", "rectangle-xmark")]
        public void Legacy_Value_Should_Be_Mapped_To_Version6(string legacy, string version6)
        {
            // Act
            var legacyPath = _iconProvider.GetIconPath($"fa-{legacy}");
            var version6Path = _iconProvider.GetIconPath($"fa-{version6}");

            // Assert
            legacyPath.Should().Be(version6Path);
        }
    }
}