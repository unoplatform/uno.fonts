# Mapping from Fluent UI System Icons to Uno FluentUI Assets

The table below indicates the icons from [Fluent UI System Icons](https://github.com/microsoft/fluentui-system-icons) that are currently used in Uno FluentUI Assets, with the glyph positions they are mapped to.

Where the icons don't exactly align, this is indicated by the notes. The 'Filled' column indicates whether the Filled icon variant was used. 

The 'Couldn't Find' column indicates glyphs for which even an imperfect match for the Segoe UI assets could not be found. In these cases, original icons were created in a Fluent Design style. The assets for those icons can be found [here](../src/assets).

## Fluent UI System Icons mapping

| Unicodes | Segoe                   | FluentUI Best Match                 |Accuracy | Notes                                                                              | Couldn't find | Filled? |
|----------|-------------------------|-------------------------------------|---------------------------|------------------------------------------------------------------------------------|---------------|---------|
| E8FB     | Accept                  | Checkmark                           |                           |                                                                                    |               |         |
| E710     | Add                     | Add                                 |                           |                                                                                    |               |         |
| F0AF     | ArrowRight8             | Arrow Forward                       |                           |                                                                                    |               |         |
| E799     | AspectRatio             | App Span? App recent?               | !                         | closest available, not   great                                                  |               |         |
| E787     | Calendar                | Calendar                            | similar              | Softer edges                                                                       |               |         |
| E722     | Camera                  | Camera                              | similar              | Softer edges                                                                       |               |         |
| E711     | Cancel                  | Dismiss                             |                           |                                                                                    |               |         |
| E8C1     | Characters              | Local Language                      | similar              | different Japanese character, but otherwise similar                     |               |         |
| E73E     | CheckMark               | CheckMmark                          |                           |                                                                                    |               |         |
| E001     | CheckMark (E73E)        | Checkmark                           |                           |                                                                                    |               |         |
| E081     | CheckMark (E73E)        | Checkmark                           |                           |                                                                                    |               |         |
| E10B     | CheckMark (E73E)        | Checkmark                           |                           |                                                                                    |               |         |
| E0E4     | ChecvronUp (E70E)       | Chevron Up                          |                           |                                                                                    |               |         |
| E70D     | ChevronDown             | Chevron Down                        |                           |                                                                                    |               |         |
| E0E5     | ChevronDown (E70D)      | Chevron Down                        |                           |                                                                                    |               |         |
| E96E     | ChevronDownSmall        | Chevron Down                        | similar              | Not bold, not "small"                                                              |               |         |
| E0E2     | ChevronLeft (E76B)      | Chevron Left                        |                           |                                                                                    |               |         |
| E76C     | ChevronRight            | Chevron Right                       |                           |                                                                                    |               |         |
| E0E3     | ChevronRight (E76C)     | Chevron Right                       |                           |                                                                                    |               |         |
| E74D     | Delete                  | Delete                              | similar              | similar                                                                       |               |         |
| E70F     | Edit                    | Edit                                |                           |                                                                                    |               |         |
| EB9D     | FastForward             | Fast Forward                        | similar              | Triangles are conjoined                                                            |               |         |
| E734     | FavoriteStar            | Star                                | similar              | Softer edges                                                                       |               |         |
| E735     | FavoriteStarFill        | Star                                |                           |                                                                                    |               | x       |
| E00A     | FavoriteStarFill (E735) | Star                                |                           |                                                                                    |               | x       |
| E082     | FavoriteStarFill (E735) | Star                                |                           |                                                                                    |               | x       |
| E11A     | Find                    | Search                              | similar              | Flipped Vertically                                                                 |               |         |
| E740     | FullScreen              | Arrow Maximize                      |                           |                                                                                    |               |         |
| E700     | GlobalNavigationButton  | Navigation                          |                           |                                                                                    |               |         |
| EB52     | HeartFill               | Heart                               |                           |                                                                                    |               | x       |
| E946     | Info                    | Info                                |                           |                                                                                    |               |         |
| E715     | Mail                    | Mail                                | similar              | Softer edges                                                                       |               |         |
| E89C     | MailForward             | Mail Move To Focussed               | similar              | Mail is open                                                                       |               |         |
| EC15     | MiracastLogoSmall       | Cast                                | similar              | Cast bottom left instead of top right                                            |               |         |
| E10C     | More (E712)             | More                                |                           |                                                                                    |               |         |
| 03A3     | N/A                     | AutoSum                             |                           |                                                                                    |               |         |
| E893     | Next                    | Next                                |                           |                                                                                    |               |         |
| E8B9     | Picture                 | Picture in Picture                  | similar              | Picture in picture instead of one overlaid on other                             |               |         |
| E718     | Pin                     | Pin                                 | similar              | Pin turned 45 degrees   counter-clockwise                                          |               |         |
| E768     | Play                    | Play                                |                           |                                                                                    |               |         |
| EC57     | PlaybackRate1x          | Play Circle                         | !                         | no arrow indicator                                                                 |               |         |
| E892     | Previous                | Previous                            |                           |                                                                                    |               |         |
| E915     | RadioBullet             | Radio Button                        |                           |                                                                                    |               | x       |
| E7A6     | Redo                    | Arrow Redo                          |                           |                                                                                    |               |         |
| E72C     | Refresh                 | Arrow Clockwise                     | similar              | Tilted 45% clockwise                                                               |               |         |
| E8EE     | RepeatAll               | Arrow Repeat All (Arrow Clockwise?) | similar              | Similar, but two arrows instead of just one loop                 |               |         |
| EB9E     | Rewind                  | Rewind                              | similar              | Triangles are conjoined                                                            |               |         |
| E74E     | Save                    | Save                                |                           |                                                                                    |               |         |
| E713     | Setting                 | Settings                            |                           |                                                                                    |               |         |
| E8B1     | Shuffle                 |                                     |                           |                                                                                    | X             |         |
| ED3C     | SkipBack10              |                                     |                           |                                                                                    | X             |         |
| ED3D     | SkipForward30           |                                     |                           |                                                                                    | X             |         |
| E71A     | Stop                    | Stop                                |                           |                                                                                    |               |         |
| ED1E     | Subtitles               | Chat                                | similar              | Softer edges                                                                       |               |         |
| ED1F     | SubtitlesAudio          | TextBox Align Bottom                | !                         | No audio icon. No little arrow to make it look more like a chat bubble           |               |         |
|          | Sugest                  | Read Aloud                          |                           |  |               |         |
| E7A7     | Undo                    | Arrow Undo                          |                           |                                                                                    |               |         |
| E9CE     | Unknown                 | Question Circle                     |                           |                                                                                    |               |         |
| E767     | Volume                  | Speaker                             |                           |                                                                                    |               |         |
| E909     | World                   | Globe                               | similar              | Less detailed. Grid vs   countries                                                 |               |         |
| E73C     | CheckboxIndeterminate   |                                     |                           |                                                                                    |               |         |
| F78D     | RevealPasswordMedium    | Eye Show                            |                           |                                                                                    |               |         |