using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Security;
using MattBaines.Data;


    public class DataContextInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            DataAccess _db = new DataAccess();


            // Init Categories and Objects
            List<AdvertisingCreativeCategory> Categories = new List<AdvertisingCreativeCategory>();
            Categories.Add(new AdvertisingCreativeCategory()
            {
                Name = "BBH Shanghai",
                Colour = "#d0605c",
                SortOrder = 1,
                ImagePath = "BBH.png"
            });

            Categories.Add(new AdvertisingCreativeCategory()
            {
                Name = "TBWA London",
                Colour = "#d0605c",
                SortOrder = 2,
                ImagePath = "TBWA.png"
            });
            Categories.Add(new AdvertisingCreativeCategory()
            {
                Name = "Momentum Manchester",
                Colour = "#70c4cb",
                SortOrder = 3,
                ImagePath = "Momentum.png"
            });
            Categories.Add(new AdvertisingCreativeCategory()
            {
                Name = "Proactive Work",
                Colour = "#e9fd09",
                SortOrder = 4,
                ImagePath = "Proactive.png"
            });

            foreach (var category in Categories.OrderBy(x => x.SortOrder))
            {
                _db.AddAdvertisingCreativeCategory(category);
            }

            _db.AddAdvertisingCreativeObject(new AdvertisingCreativeObject()
            {
                Title = "Sprite",
                Content = "<p>Work 1</p>",
                ImagePath = "Sprite_logo.png",
                Category = Categories[0],
                SortOrder = 1
            });
            _db.AddAdvertisingCreativeObject(new AdvertisingCreativeObject()
            {
                Title = "Ice Dew",
                Content = "<p>Ice Dew</p>",
                ImagePath = "icedew.png",
                Category = Categories[0],
                SortOrder = 2
            });
            _db.AddAdvertisingCreativeObject(new AdvertisingCreativeObject()
            {
                Title = "Work 3",
                Content = "<p>Work 3</p>",
                ImagePath = "Sprite_logo.png",
                Category = Categories[0],
                SortOrder = 3
            });
            _db.AddAdvertisingCreativeObject(new AdvertisingCreativeObject()
            {
                Title = "Army",
                Content = string.Concat("<p><img src=\"../../Content/images/AdvertisingCreative/ArmyCareer.jpg\" border=\"0\" /></p>",
                                        "<p><span style=\"font-size: large; text-decoration: underline;\"><strong>Soldier Begin!!</strong>",
                                        "</span><br /><span style=\"font-size: large;\">School&rsquo;s over, now it&rsquo;s time for your real ",
                                        "assessment with a career as a soldier. </span><span style=\"font-size: large;\">In the army caving is ",
                                        "seen as the perfect test of a soldier&rsquo;s resolve. By negotiating </span><span style=\"font-size: large;\">",
                                        "pitches, squeezes and underground water the same cool head you used to ace that </span><span style=\"font-size: large;\">",
                                        "big exam will again be pushed to the limit. Find out more about this from an </span><span style=\"font-size: large;\">",
                                        "experienced soldier. </span><br /> <br /><span style=\"font-size: large;\"><strong><span style=\"text-decoration: underline;\">",
                                        "Get Inside the Action</span></strong></span><br /><span style=\"font-size: large;\">In this issue you&rsquo;ll ",
                                        "learn about the bugle sounded at the charge of the light brigade, </span><span style=\"font-size: large;\">and find ",
                                        "out why Lieutenant-General Sir Adrian Carton de Wiart is considered one </span><span style=\"font-size: large;\">of ",
                                        "the most remarkable soldiers in British History.</span><span>&nbsp;&nbsp;</span><span style=\"font-size: large;\">",
                                        "Start the search for your new career now. Go to&nbsp;<a href=\"http://www.armyjobs.mod.uk\" target=\"_blank\">www.armyjobs.mod.uk</a></span></p>"),
                ImagePath = "british-army-logo.png",
                Category = Categories[1],
                SortOrder = 1
            });
            _db.AddAdvertisingCreativeObject(new AdvertisingCreativeObject()
            {
                Title = "Oats & More",
                Content = "<p>Work 5</p>",
                ImagePath = "OatsAndMore.png",
                Category = Categories[2],
                SortOrder = 1
            });
            _db.AddAdvertisingCreativeObject(new AdvertisingCreativeObject()
            {
                Title = "The Dishwasher Conundrum",
                Content = "<p><img src=\"../../Content/images/AdvertisingCreative/DishwasherConundrum.jpg\" border=\"0\"/></p>",
                ImagePath = "Dishwasher.png",
                Category = Categories[3],
                SortOrder = 2
            });
            _db.AddAdvertisingCreativeObject(new AdvertisingCreativeObject()
            {
                Title = "Oxfam",
                Content = "<p>Work 7</p>",
                ImagePath = "oxfam.png",
                Category = Categories[3],
                SortOrder = 3
            });
            _db.AddAdvertisingCreativeObject(new AdvertisingCreativeObject()
            {
                Title = "Play It!",
                Content = "<p>BRIEF Play It - Increase the awareness of Play It’s extensive range of games to hire or rent.</p>",
                ImagePath = "playit.png",
                Category = Categories[3],
                SortOrder = 1
            });

            _db.AddWorkILike(new WorkILike()
            {
                Type = "Articles",
                Title = "Fashion and Poetry and Never the Twain Shall Meet",
                Course = "MA Falmouth",
                Year = "2012",
                Summary = @"<p style=""text-align: justify;"">I&rsquo;ve always been suspicious of the power spoken word has over its readers. To me poetry should be&nbsp;read sitting in the comfiest of chairs, next to the hottest of fires; with a cup of whisky in one hand and&nbsp;a jar of smouldering enthusiasm in the other. It should be toil, like visiting the dentist; you&rsquo;ll feel better&nbsp;afterwards. Upon the seventh read words and meanings should still be hard to decipher and curiosity&nbsp;should bring you back for an eighth read. Because of its immediacy spoken Poetry has never been&nbsp;something I&rsquo;d thought of attending&hellip;until now. I heard through the proverbial grapevine that there was&nbsp;a free amateur (is there any other kind?) poetry reading in Manchester and anyone was welcome to&nbsp;attend. My&nbsp;house mates&nbsp;told me they were going and far from being the social outcast people take me&nbsp;to be, I agreed, if only for the promise of Beetroot cake.</p>
                            <p style=""text-align: justify;"">With cake at the forefront of my brain six of us crammed into my amused pal's Fiat Punto and we all&nbsp;set off, slowly. We then struggled for an hour to find the place before eventually stumbling upon a&nbsp;discreet cafe door at the bottom of some old worn out steps; the sign outside read 'Poetry, tonight'.&nbsp;As we walked through the cafe door I could see a crowd was gathered around the counter ordering&nbsp;cake and coffee and a slight twitch of anxiety rose in my stomach &ndash; the portions of Beetroot cake&nbsp;were dwindling, fast. The lady behind the counter, for whatever reason, hadn&rsquo;t noticed the faint&nbsp;spasm of alarm in my right eye and continued to dish out Beetroot Cake with an unerring, and slightly&nbsp;infuriating, smile. As the last pieces of Beetroot cake were disappearing I had already resigned myself&nbsp;to a fate of non-desired cake and coffee. So when the guy in front of me turned to his girl and said &ldquo;I&nbsp;love Beetroot Cake, not seen it in a while, maybe I&rsquo;ll get two pieces and take a slice home for Mum&rdquo;&nbsp;the anger I felt was less than it might have been.</p>
                            <p style=""text-align: justify;"">By the time we arrived at the front of the queue we could hear the poets in the other room introducing&nbsp;themselves. It was about to start. I looked around for someone to take an order and the smiley lady&nbsp;trundled over. Her green eyeliner carelessly plastered above her eyes and her tasteless, ill-fitting dress scraped along the floor. Too defeated to look for myself I asked the lady which flavour of cake&nbsp;she had left. &nbsp;&ldquo;Well, my dear&rdquo; the lady replied, &ldquo;we have, erm, let me see, Carrot cake, Lemon cake,&nbsp;Fruit cake, Sticky Toffee Pudding and, oh, Beetroot Cake.&rdquo; A grin spread across my face and like a child about to get his own way, said through shiny teeth &ldquo;Beetroot Cake, please&rdquo;. She smiled, her&nbsp;beautiful smile, turned like a ballerina on Broadway before gliding to the back of the kitchen to retrieve a freshly baked Beetroot cake. Upon her return she not only handed over the Beetroot cake but also a carrot which, apparently, goes splendidly well with said cake. Her eyes looked at me as if to say &ldquo;you lucky devil, you&rdquo;.</p>
                            <p style=""text-align: justify;"">With food and coffee bought I hurried to my seat trying, simultaneously to keep the fresh carrot from falling onto the grimy floor whilst squeezing through the tightly knit chairs without making too much noise. All-in-all a pretty difficult task but as I neared the rest of my clan &ndash; carrot still balanced on the plate I afforded myself a quick smile for what I thought was a job well done. My illusions were swiftly shattered when, as I was about to take my seat, the head reader barked at me to hurry up and quieten down. Upon hearing this I realised I&rsquo;d been less than quiet. Mumbling a pathetic &ldquo;sorry&rdquo; I quickly sat down and a night of potential boredom morphed into a night of humiliation before, upon hearing the laughter ringing around, slight anger.</p>
                            <p style=""text-align: justify;"">From then on the night seemed to pass quite quickly. Four main readers sat down and read a selection of poems from their most recent books. All were different and all were of great interest. Hearing the words for the first time was a very pleasant experience. Untainted by prior conceptions I could enjoy the theatrical performances that each poet produced without searching for deeper meaning. These were poems made to be spoken and were spoken incredibly well. One of the poets</p>
                            <p style=""text-align: justify;"">was particularly theatrical. He read each poem with a comedic mix of fire and confusion, saying more with precise silences than he did with the words. On one occasion he stopped for so long, confusion etched upon his face, that cries of laughter began to rise and grow until he spoke again. Now that&rsquo;s confidence in your comedy timing, I thought. I feel that if this poetry reading taught me anything it was that in order to be successful in poetry perhaps the poet has to be as good a performer as he is a writer.</p>
                            <p style=""text-align: justify;"">As the &lsquo;floor&rsquo; opened to other aspiring poets the rest of the room came into focus. And as I looked around at the assembled horde it struck me that not one of the hundred strong crowd looked out of place. They were all wearing similar black shoes, dark coloured jeans and an assortment of jumpers. Seemingly not one of them held fashionable ideals. The whole scene reminded me of a time not too long ago when I was trying to break into Advertising as a Copywriter. I was sat outside a pub having a drink (in hind-sight possibly the reason I couldn&rsquo;t pin down a job) with a pal when he told me to look at two guys walking down the street. They were, he said, two of the best &lsquo;creatives&rsquo; in London. There was only one question on my mind &ndash; which was the Copywriter? My friend looked at me as if I&rsquo;d asked him what material trees are made from, before replying in a curt way &ldquo;the one with the frayed jeans, obviously&rdquo;. Having got my answer I neglected to pursue the line of questioning any further. I thought it was an unfair contest; of course an artist who deals solely in aesthetics is going to look better than a writer. But after mentally comparing last night&rsquo;s bunch of writers to ordinary people his prophecy struck me again, why do all writers have such terrible dress sense?</p>
                            <p style=""text-align: justify;"">Fashionable writers certainly seem to be the exception rather than the rule. For every Oscar Wilde there are a thousand Philip Larkins. When the great novelist Gilda Radner was asked about her wardrobe she replied &ldquo;I base my fashion sense on what doesn&rsquo;t itch.&rdquo; A sentiment that echoes through a literary world that holds fashion in mild contempt. Quentin Crisp reiterates this view when he says &ldquo;Fashion is what you adopt when you don&rsquo;t know who you are.&rdquo; Personally I think to follow fashion is to follow your generation. How can you write about your generation when you know nothing of them? Nothing of what drives a man to buy pink skin tight jeans or a woman to slip into UGG boots without a thought. The intricacies of style and fashion can be windows into a person&rsquo;s soul and should never be overlooked. Give me Oscar Wilde over Philip Larkin any day.</p>
                            <p style=""text-align: justify;"">Back in the room and events were coming to an end. The main speaker, that grotty fellow, fed his egocentricity and read the last poem &ndash; some awful number about misanthropy &ndash; before some lady came in to tell us she was shutting the cafe and we all had to leave, pronto. No time for chats and more coffee, old chaps. As I walked out I felt something hard in my pocket I reached in to find a pear that the nice lady from earlier had given me, free of charge, what a treat. Munching on my pear I couldn&rsquo;t help but think that on the whole it had been a very interesting and successful night. In this digital age perhaps everybody needs to be more open minded about how they consume their art of choice. Spoken word adds much to art allowing readers of a whole plethora of poetry to enjoy their favourite poets through iPods, Laptops, Radio, etc, and it should certainly not be discounted. I for one will certainly be attending more poetry readings though next time I&rsquo;ll be sure to get there early.</p>"
            });
            _db.AddWorkILike(new WorkILike()
            {
                Type = "Story Ideas",
                Title = "The Importance Of Pee",
                Course = "MA Falmouth",
                Year = "2012",
                Summary = @"<p dir=""ltr"">The rules were simple; whoever called the meeting had to host the thing. Pee, as usual, had a pressing concern and so, on this cold morn, dragged the only two men in the world worthy of his time to the bunker outside his parent&rsquo;s house.</p>
<p dir=""ltr""><span>Pee flicked through his journal one last time; between lists titled &lsquo;significant advances in science&rsquo;, &lsquo;favourite sporting icons and their wives&rsquo;, &lsquo;daily routine&rsquo;, etc, he stumbled across, &lsquo;Bunker events &ndash; meeting&rsquo;. Pee rang his fingers over the crumpled paper list and checked off each of the list&rsquo;s points. He smiled; everything was in place and he was ready.</span></p>
<p dir=""ltr""><span>When the young men entered the bunker they found Pee stood with wine in one hand, hors d&rsquo;oeuvres in the other and Modest Mouse blazing from the loud speakers &ndash; a ruse in having complete control over his guests as they arrived. It hadn&rsquo;t worked.</span></p>
<p dir=""ltr""><span>&ldquo;Sweet, food&rdquo;, shouted Boyman grabbing a Salmon Blini and throwing it at Glassy. Glassy smirked before removing his glasses and kneeling in front of Boyman. &ldquo;Oh Boyman, you with your sweet eyes and hairy back are more than me. Your penis lumpy and large is more than my eyes can behold. Your hair and rippling muscles are gladiatorial, Boyman, show me how I can transcend the gap in manliness that is so palpable between us&hellip;&rdquo; He then spat on Boyman&rsquo;s foot and walked over to the chair Pee had earmarked for him, and sat down. Boyman roared with laughter before sitting himself next to Glassy.</span></p>
<p dir=""ltr""><span>Shaking his head, Pee lowered the volume on the cassette player and addressed his friends with the confidence of a man about to achieve things beyond the expectations of most of humanity &ldquo;men, as you know, next week I will catch a flight to Tanzania with the express interest of tackling the largest mountain in Africa&rsquo;s entirety. The summit of Kilimanjaro is a dream for most men, next week I make that dream REALITY&rdquo;. Pee looked around his friends, expectantly. Glassy was staring intently at the pictures on the wall whilst Boyman, Pee&rsquo;s oldest friend, had his nose crumpled and was shaking his head in complete disgust.</span></p>
<p dir=""ltr""><span>&ldquo;Dude, it smells like Cracka Jacks in here. You been smoking those Cracka Jacks again?&rdquo; Pee glared at him, sighed, and then slowly sat down in his seat.</span></p>
<p dir=""ltr""><span>&ldquo;That was one time, Bee-oyy-man, and anyw&hellip;&rdquo;</span></p>
<p dir=""ltr""><span>&ldquo;It wasn&rsquo;t actually, you smoked Doritos and HP Sauce with Jade in second year because Glassy told you Doritos had the ability to render a woman completely submissive.&rdquo;</span></p>
<p dir=""ltr""><span>Pee spluttered, &ldquo;Glassy&rsquo;s a cunt for telling me that. I would never have played a shitty trick like that on either of you&rdquo;</span></p>
<p dir=""ltr""><span>The boys guffawed with laughter, &ldquo;Peeeee, come on, man, it worked an absolute dream. How long were you banging her before she realised she&rsquo;d neglected her studies for a loafer? Four years?&rdquo;</span></p>
<p dir=""ltr""><span>Pee&rsquo;s confidence shrank and his mood changed markedly as the memory of his ex girlfriend ghosted through his mind. Glassy noticed and quickly interjected &ldquo;What Boyman meant to say was, you know, four years is a long time and&hellip;&rdquo;</span></p>
<p dir=""ltr""><span>&ldquo;One vagina in four, dude!! You know how many chicks I&rsquo;ve fucked in the time you two have been together? Thirty-three. Thirty-three vaginas. If they climbed on top of each other do you know how tall thirty-three vaginas would be? Do you?&rdquo;</span></p>
<p dir=""ltr""><span>Glassy held his head in his hands, aware as he was of Pee&rsquo;s sensitivity on the subject of anything female related, but equally aware of how persistent Boyman could be once an idea had taken hold.</span></p>
<p dir=""ltr""><span>&ldquo;They&rsquo;d be taller than Everest. So, you talk about Kilimanjaro like it&rsquo;s such a big deal but really, I&rsquo;ve conquered a taller structure than you ever will&hellip;&rdquo; Boyman placed his hands on his hips proudly.</span></p>
<p dir=""ltr""><span>Pee laughed &ldquo;that, my friend is the most ridiculous argument I&rsquo;ve ever heard. Climbing Kilimanjaro is three thousand times as dangerous as dividing your genitals between thirty three girls. I imagine you&rsquo;ve had most types of STD and you still seem to function &ndash; function in the scientific sense of the word. Talking about Everest clearly shows your naivety on the subject. There are more deaths on Kilimanjaro than any other mountain. Evidently you have to be some man to climb it, so whilst you&rsquo;re &lsquo;banging&rsquo; girl number thirty four I&rsquo;ll be striving for something of much more significance.&rdquo; Pee had regained a considerable amount of his swagger. &ldquo;Climbing and conquering the most dangerous mountain around&rdquo;</span></p>
<p dir=""ltr""><span>&ldquo;You do realise the only reason fatality rates are higher on Kilimanjaro is because it&rsquo;s the easiest of the mountains, so more people attempt it&rdquo; Glassy interjected begrudgingly, he didn&rsquo;t want to bring Pee down at this point but his nature dictated that he must correct someone when they clearly hadn&rsquo;t assessed every angle of the argument.</span></p>
<p dir=""ltr""><span>&ldquo;Anyway, this is the reason I dragged you here today. Regardless of what Glassy &lsquo;believes&rsquo;&rdquo;, said, Pee, flustered and irritated by what he perceived to be Glassy&rsquo;s unsupportive rhetoric &ldquo;Kilimanjaro is a monstrous challenge and one which I would like the two women who so cruelly took their love from me to pay witness to&rdquo; Pee gestured to the glowing pictures of two beautiful, naked women, which adorned the wall.</span></p>
<p dir=""ltr""><span>Glassy looked at the pictures. I&rsquo;m not sure that Jade would like us to see her in such a position; I doubt you pay much regard to her feelings. Who is the other gi&hellip;&rdquo;</span></p>
<p dir=""ltr""><span>&ldquo;You rat. I can&rsquo;t believe you&rsquo;ve been dabbling in two girls. Your cock must be exhausted from all the ram-jamming.&rdquo;</span></p>
<p dir=""ltr""><span>&ldquo;It&rsquo;s not like that at all. I invite you to read the plaques and please tell me your thoughts.&rdquo;</span></p>
<p dir=""ltr""><span>Glassy and Boyman looked at each other, before rising from their leather chairs and moving swiftly over to the girl neither boy recognised. The picture encompassed a pretty black haired girl with small breasts gazing innocently out of a window.</span></p>
<p dir=""ltr""><span>&ldquo;she&rsquo;s beautiful&rdquo; Glassy commented &ldquo;so elegant, I have no idea how such a girl could be interested in&rdquo; with a teasing grin Glassy pointed at Pee and waved his hand up and down&rdquo;</span></p>
<p dir=""ltr""><span>&ldquo;Oh, my God, you&rsquo;re a sick fuck, Pee&rdquo;, Boyman screamed</span></p>
<p dir=""ltr""><span>&ldquo;I am not&rdquo; Pee shouted, &ldquo;These are merely women who have had the most influence on my life. I feel it is my duty to remember these dears for who they were without the trickery of fashion.&rdquo;</span></p>
<p dir=""ltr""><span>Boyman read the plaque aloud snorting with laughter and condescension as he did.</span></p>
<p dir=""ltr""><span>&ldquo;February 1</span><span>st</span><span> 1993 &ndash; March 24</span><span>th</span><span> 2000. </span></p>
<p dir=""ltr""><span>Daisy was a softly spoken woman. A keen gardener. Often wise and of perpetual intelligence &ndash; Her insights on matters of the heart always proved invaluable. Her mind, like her garden, had great care afforded its development &ndash; to behold its beauty and vibrant colours was always a pleasure. Daisy Tucker: Mother of Pee Tucker&rdquo;</span></p>
<p dir=""ltr""><span>&ldquo;There&rsquo;s a strange macabre beauty to that, Pee&rdquo; said Glassy, softly, &ldquo;however you choose to remember your mother is fine by me.&rdquo; Glassy looked over at Boyman nudging him to agree and diffuse the situation.</span></p>
<p dir=""ltr""><span>&ldquo;Yeah, yeah, you do what you feel is best, Pee.&rdquo; Boyman said barely able to contain his amusement.</span></p>
<p dir=""ltr""><span>Before Pee could speak Glassy moved hastily over to the other plaque and began to read;</span></p>
<p dir=""ltr""><span>&ldquo;January 2006 &ndash; November 2010. </span></p>
<p dir=""ltr""><span>Jade had great temerity in all her endeavours. She will be mostly fondly remembered for her summit of Mount Everest circa 08:13 January 18</span><span>th </span><span>2010, and the valiant way in which she recovered from a failed ascent of Kilimanjaro circa July 20</span><span>th</span><span> 2010. Jade Mallory: Girlfriend of Pee Tucker.&rdquo; </span></p>
<p dir=""ltr""><span>As Boyman finished, both lads where in fits of giggles, they knew Pee was eccentric but even they didn&rsquo;t think he could be so strange.</span></p>
<p dir=""ltr""><span>&ldquo;The mother one is weird enough&rdquo;, said Glassy, &ldquo;but Jade Mallory isn&rsquo;t dead I saw her with Branny Faberton outside Harrods as we made our way over here.&rdquo; </span></p>
<p dir=""ltr""><span>&ldquo;Chaps, this isn&rsquo;t a funeral wall, it&rsquo;s a celebration of two very special women. It&rsquo;s a celebration of the time I had with them. I&rsquo;m under no illusions that Jade is living, and living well, but to me she will always be remembered for the four years we spent together, because that is the time when she had most significance upon my life. She was beautiful and fearless in all the ways I imagined before we started dating. </span></p>
<p dir=""ltr""><span>&ldquo;You brought us here to ask our advice on climbing Kilimanjaro. When it&rsquo;s clear the only reason you&rsquo;re trying to achieve this feat is to impress some girl &ndash; who you&rsquo;re clearly not over.&rdquo; said Boyman, &ldquo;Instead of climbing mountains in an attempt to surpass her you should send her flowers and remind her that you still love her very much&rdquo;</span></p>
<p dir=""ltr""><span>Glassy and Pee were taken aback, it suddenly dawned on them that Boyman, for all his bravado, was right. Pee looked at the floor then stared at the boys with a renewed strength neither of them knew he possessed. In that instance they realised; he would no longer be going to Tanzania.</span></p>"
            });
            _db.AddWorkILike(new WorkILike()
            {
                Type = "Interviews",
                Title = "9 Questions: Hazel Davis",
                Course = "MA Falmouth",
                Year = "2012",
                Summary = @"<p dir=""ltr""><span>This week, by the power of my mind, I winged 9 questions to Freelance Journalist/Copywriter, Hazel Davis. Hazel is a great freelance writer who has published in The Guardian, The Independent, The Telegraph and Word, amongst others.</span><span></span></p>
<p dir=""ltr""><a href=""http://www.hazeldavis.co.uk/""><span>http://www.hazeldavis.co.uk/</span><strong></strong></a></p>
<p dir=""ltr""><strong>What is the best thing about being a freelance writer?</strong><span></span></p>
<p dir=""ltr""><span>The best thing? Being my own boss and being able to work from where I like and when I like.</span><strong></strong></p>
<p dir=""ltr""><strong>When did you first realise that writing would become your vocation? And what would you have done if you had not become a writer?</strong><span></span></p>
<p dir=""ltr""><span>Hmm. Not sure if it&rsquo;s a vocation! I always liked writing as a child and I used to say I wanted to be a journalist. Then I went to university and did an MA in linguistics and started a PhD in&nbsp;computational linguistics with a view to becoming an academic. But I loathed it. So maybe something in linguistics research or failing that, working with special needs.</span><strong></strong></p>
<p dir=""ltr""><strong>What are your future goals, in writing or otherwise?</strong><span></span></p>
<p dir=""ltr""><span>Hmm. Just to keep on earning a living from writing and working for myself. The very idea of working for anyone else ever again makes me feel very sick indeed.</span><strong></strong></p>
<p dir=""ltr""><strong>Which is your favourite article of yours and why?</strong><span></span></p>
<p dir=""ltr""><span>Dunno! Maybe this&nbsp;</span><a href=""http://www.guardian.co.uk/society/2008/mar/12/care.farms""><span>one?</span></a><span>&nbsp;Don&rsquo;t really have a favourite.</span><strong></strong></p>
<p dir=""ltr""><strong>Who is your favourite journalist?</strong><span><br class=""kix-line-break"" />I love Robert Crampton who writes in the Times and I think Simon Hattenstone (Guardian) is a great interviewer.</span><span></span></p>
<p dir=""ltr""><strong>Favourite author/novel?</strong><span></span></p>
<p dir=""ltr""><span>God so many. Steinbeck though, all the way, Cannery Row is my favourite though not necessarily his &ldquo;best&rdquo;. I love Murakami too and I really love The Buddha Of Suburbia.</span><strong></strong></p>
<p dir=""ltr""><strong>What is it about ventures like the Hepton singers that you find so appealing? Are you naturally drawn to activities that are inherently creative?</strong><span></span></p>
<p dir=""ltr""><span>Hmm. I just love singing! I have always loved singing. I&rsquo;m not necessarily creative particularly. I&rsquo;m musical and it just happened to be a choir I joined, which I loved and love.</span><strong></strong></p>
<p dir=""ltr""><strong>Many great writers like Roald Dahl, Margaret Atwood, etc, have a hideaway where they feel shut off from worldly distractions and can concentrate solely on their writing. Have you got a special place/or certain conditions that help the words to flow? Would you advice it for any would-be writers?</strong><span></span></p>
<p dir=""ltr""><span>Not really no. I find that deadlines help the words flow. I can have all the calming music, incense, sound of birds in the world and it wouldn&rsquo;t help. My advice is to get on with it!!</span><strong></strong></p>
<p dir=""ltr""><strong>Have you any aspirations of comedy greatness? Who would you base your comedic stylings upon?</strong><span></span></p>
<p dir=""ltr""><span>Er none. I am NOT funny at all!</span><span></span></p>
<p><span>&nbsp;</span></p>"
            });
            _db.AddWorkILike(new WorkILike()
            {
                Title = "Is Contador’s Disfigured Reputation, Irreparable?",
                Course = "MA Falmouth",
                Year = "2011",
                Summary = @"<p dir=""ltr""><span>On Tuesday three-time Tour De France winner Alberto Contador was cleared of taking performance enhancing drugs by The Spanish Cycling Federation. A decision that one expects would leave Contador free to pursue his career, reputation unscathed. However, in the murky waters of doping and its intrinsic relationship with top-level competitive cycling the line between right and wrong has rarely been hazier. </span><span></span></p>
<p dir=""ltr""><span>Cycling is no stranger to doping scandal. Many of the sport&rsquo;s great names have at some time in their career been accused of doping or failed a test. The reason seems to lie in the difficulty of the Tour and the culture of doping ingrained in the psyche of most top level cyclists. The three great cycling tours &ndash; Tour De France, The Vuelta and The Giro Italia &ndash; are immeasurably tough; the 2010 Tour De France was 2263 miles and participants climbed the equivalent of Mount Everest four times. With this in mind it can be no surprise that the temptation to take drugs that promise quicker recovery and increased strength is, to some riders, a tonic too tantalizing to resist. </span><span></span></p>
<p dir=""ltr""><span>Many cyclists have alluded to the huge benefits doping have had on not only their career but on many of their cycling colleagues&rsquo;. The most recent cyclist to speak openly about his drug use is Bernard Kohl who, after admitting taking CERA - continuous erythropoietin receptor activator - in 2008, said &ldquo;you can&rsquo;t win the Tour De France without doping&rdquo;; after looking back at the great names who have won the Tour de France before admitting doping at a later date, this certainly seems true. Jacques Anquetil, the first man to win five Tour De Frances, once famously said &ldquo;leave me in peace. Everyone dopes.&rdquo; A sentiment echoed by Laurent Fignon, a two time winner, who said before his death in August that he was sure the doping products he took had contributed to his cancers. The transparency of these men and the often little held truth that doping was a huge and forgivable part of cycling has meant that these cycling greats have lost little of their glittering reputation through admitting to doping. After all, if everyone&rsquo;s doing it then no one gets an advantage; and the fans get to see most of their idols reach the finishing line in one piece. </span><span></span></p>
<p dir=""ltr""><span>In the media glare of the 21</span><span>st</span><span> century elite level Cycling and in particular doping has entered the spotlight like never before. This has led to more stringent doping tests and an increased penalty for even slight infringements. The less than transparent nature of doping has meant that fans automatically fear the worst for anyone caught up in doping. A case in point is the Tour great Lance Armstrong. Floyd Landis who gained the inauspicious title of being the only man stripped of his Tour de France title after he was found guilty of doping. Not only did he lose his title but was also banned for 2 years by a cycling committee. In 2010, shortly after his ban was lifted, he tried and failed to gain entry into that year&rsquo;s Tour leaving him bitter over treatment he felt was unwarranted. Subsequently Landis accused Armstrong of using similar doping methods and also participating in blood transfusions, claims Armstrong denies. All evidence against Armstrong is, so far, merely hearsay, but one only needs to type &lsquo;Lance Armstrong drugs&rsquo; into Google to see the uncertainty with which people now view his cycling triumphs - an ominous testament to the stigma that comes with such accusations, however heinous. </span><span></span></p>
<p dir=""ltr""><span>Today, cycling is the most tested sport on the planet and for good reason; stringent testing concurrently removes any doubt over a cyclist&rsquo;s guilt and room for retrospective accusations from teammates. This leaves the greats to become great free from the acrimony a doping accusation can yield. But what of other sports and doping? Mario Cipollini said in defence of Contador that he&rsquo;d like &ldquo;to see footballers submit themselves to the tests and surprise visits we (cyclists) agree to&rdquo;. Which though seemingly logical the sheer nature of cycling as a sport of endurance renders his statement obsolete - no drugs in the world could propel an average footballer to win the Ballon D&rsquo;or or an average cricketer to hit a century at the Waka. In exchange for their support sports fans demand truth through transparency; win or lose but never cheat. Where drugs compromise this, rigorous testing must take place to ensure the sports integrity and the fans piece of mind.</span></p>
<p>After being &lsquo;cleared&rsquo; of his crimes Contador left court happy but aware of the knock his reputation has taken. &ldquo;Today is a day of justice, with mixed feelings between joy and sadness for all the damage in recent months. Leaves a mark&rdquo; Tweeted Contador. And indeed it does. The great thing for the fans is that Contador will be free to resume the engrossing battle with Andy Schleck which is morphing into one of sport&rsquo;s great rivalries. The sad news for Contador is that whatever he wins from now until the day he retires will always be juxtaposed to a back drop of doping controversy. Indeed, the intangible nature of a doping accusation or positive test means that the stain upon the reputation of Contador will never truly absolve itself.</p>"
            });

            // Init Users and Roles
            WebSecurity.Register("Admin", "Admin123", "demo@demo.com", true, "Demo", "Demo");
            Roles.CreateRole("Admin");
            Roles.AddUserToRole("Demo", "Admin");
        }
    }