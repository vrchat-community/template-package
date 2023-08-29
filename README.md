# VPM Package Template

Starter for making Packages, including automation for building and publishing them.

Once you're all set up, you'll be able to push changes to this repository and have .zip and .unitypackage versions automatically generated, and a listing made which works in the VPM for delivering updates for this package. If you want to make a listing with a variety of packages, check out our [template-package-listing](https://github.com/vrchat-community/template-package-listing) repo.

## ▶ Getting Started

* Press [![Use This Template](https://user-images.githubusercontent.com/737888/185467681-e5fdb099-d99f-454b-8d9e-0760e5a6e588.png)](https://github.com/vrchat-community/template-package/generate)
to start a new GitHub project based on this template.
  * Choose a fitting repository name and description.
  * Set the visibility to 'Public'. You can also choose 'Private' and change it later.
  * You don't need to select 'Include all branches.'
* Clone this repository locally using Git.
  * If you're unfamiliar with Git and GitHub, [visit GitHub's documentation](https://docs.github.com/en/get-started/quickstart/git-and-github-learning-resources) to learn more.
* Add the folder to Unity Hub and open it as a Unity Project.
* After opening the project, wait while the VPM resolver is downloaded and added to your project.
  * This gives you access to the VPM Package Maker and Package Resolver tools.

## 🚇 Migrating Assets Package
Full details at [Converting Assets to a VPM Package](https://vcc.docs.vrchat.com/guides/convert-unitypackage)

## ✏️ Working on Your Package

* Delete the "Packages/com.vrchat.demo-template" directory or reuse it for your own package.
  * If you reuse the package, don't forget to rename it!
* Update the `.gitignore` file in the "Packages" directory to include your package.
  * For example, change `!com.vrchat.demo-template` to `!com.username.package-name`.
  * `.gitignore` files normally *exclude* the contents of your "Packages" directory. This `.gitignore` in this template show how to *include* the demo package. You can easily change this out for your own package name.
* Open the Unity project and work on your package's files in your favorite code editor.
* When you're ready, commit and push your changes.
* Once you've set up the automation as described below, you can easily publish new versions.

## 🤖 Setting up the Automation

Create a repository variable with the name and value described below.
For details on how to create repository variables, see [Creating Configuration Variables for a Repository](https://docs.github.com/en/actions/learn-github-actions/variables#creating-configuration-variables-for-a-repository).
Make sure you are creating a **repository variable**, and not a **repository secret**.

* `PACKAGE_NAME`: the name of your package, like `com.vrchat.demo-template`.

Finally, go to the "Settings" page for your repo, then choose "Pages", and look for the heading "Build and deployment". Change the "Source" dropdown from "Deploy from a branch" to "GitHub Actions".

That's it!
Some other notes:
* We highly recommend you keep the existing folder structure of this template.
  * The root of the project should be a Unity project.
  * Your packages should be in the "Packages" directory.
  * If you deviate from this folder structure, you'll need to update the paths that assume your package is in the "Packages" directory on lines 24, 38, 41 and 57.
* If you want to store and generate your web files in a folder other than "Website" in the root, you can change the `listPublicDirectory` item [here in build-listing.yml](.github/workflows/build-listing.yml#L17).

## 🎉 Publishing a Release

You can make a release by running the [Build Release](.github/workflows/release.yml) action. The version specified in your `package.json` file will be used to define the version of the release.

## 📃 Rebuilding the Listing

Whenever you make a change to a release - manually publishing it, or manually creating, editing or deleting a release, the [Build Repo Listing](.github/workflows/build-listing.yml) action will make a new index of all the releases available, and publish them as a website hosted fore free on [GitHub Pages](https://pages.github.com/). This listing can be used by the VPM to keep your package up to date, and the generated index page can serve as a simple landing page with info for your package. The URL for your package will be in the format `https://username.github.io/repo-name`.

## 🏠 Customizing the Landing Page (Optional)

The action which rebuilds the listing also publishes a landing page. The source for this page is in `Website/index.html`. The automation system uses [Scriban](https://github.com/scriban/scriban) to fill in the objects like `{{ this }}` with information from the latest release's manifest, so it will stay up-to-date with the name, id and description that you provide there. You are welcome to modify this page however you want - just use the existing `{{ template.objects }}` to fill in that info wherever you like. The entire contents of your "Website" folder are published to your GitHub Page each time.

## ⚙️ Automating Unit Tests (Optional)

> :warning: **As of August 2023, Unity has ended support for offline activation of Personal Licenses.**
> Due to this change, these steps to automate Unit Tests and generate Code Coverage on GitHub Actions will now only work with Unity Plus or Unity Pro Licenses.
> You can still run Unit Tests manually from within the Unity Editor with a Personal License.

Create repository variables with the names and values described below.
Once again, make sure you are creating a **repository variable**, and not a **repository secret**.

* `UNITY_VERSION`: The Unity Version to use for your build.
  * Use the [current VRChat-compatible Unity Version](https://creators.vrchat.com/sdk/current-unity-version).
  * As of August 2023, this version is `2019.4.31f1`.
* `ASSEMBLY_NAME`: The Assembly name of your package.
  * This is different than your package name. For example, this template package's assembly name is `VRChatPackageTemplate`, from `VRChatPackageTemplate.asmdef`.
* `REQUIRED_COVERAGE`: The percentage of [Code Coverage](https://docs.unity3d.com/Packages/com.unity.testtools.codecoverage) (from 0 to 100) that you want to require before a release can be published.
  * If you don't want to enforce any Code Coverage requirements, set this value to 0.

Create repository secrets with the names and values described below.
For details on how to create repository secrets, see [Creating Encrypted Secrets for a Repository](https://docs.github.com/en/actions/security-guides/encrypted-secrets#creating-encrypted-secrets-for-a-repository).
This time, make sure you are creating **repository secrets**, and not **repository variables**.

> :warning: **These secrets contain sensitive information that could compromise your Unity account if exposed!**
> To keep them safe, you should only ever input these values as GitHub Actions encrypted secrets!
> Never commit these secrets directly to source control!

* `UNITY_EMAIL`: The email address associated with your Unity account.
* `UNITY_PASSWORD`: The password for your Unity account.
* `UNITY_SERIAL`: Your Unity Plus or Unity Pro serial number.
  * For more information, see ["How do I find my license serial number?"](https://support.unity.com/hc/articles/209933966-How-do-I-find-my-license-serial-number).

Ensure that your Tests and Test Assemblies match the locations and naming conventions from the [official Unity documentation](https://docs.unity3d.com/Manual/cus-tests.html), such as in these examples:
* `Assets/Packages/<PACKAGE_NAME>/Tests/Editor/<ASSEMBLY_NAME>.Editor.Tests.asmdef`
* `Assets/Packages/<PACKAGE_NAME>/Tests/Editor/<Your Tests Here>.cs`
* `Assets/Packages/<PACKAGE_NAME>/Tests/Runtime/<ASSEMBLY_NAME>.Tests.asmdef`
* `Assets/Packages/<PACKAGE_NAME>/Tests/Runtime/<Your Tests Here>.cs`

If you only have Editor Tests or Runtime Tests, that's okay.
You can safely delete the unused directory and its assembly definition.

For more information on unit testing your VPM package, see ["Adding Tests to a Package"](https://docs.unity3d.com/Manual/cus-tests.html).

## 📛 Setting up Badges (Optional)

What is a GitHub Repository without cool [badges](https://shields.io/)?

Once you have [published your repository's listing](#-rebuilding-the-listing) to GitHub Pages, you can use add a badge that displays your current VPM version:

[![VPM Package Version](https://img.shields.io/vpm/v/com.vrchat.demo-template?repository_url=https%3A%2F%2Fdustuu.github.io%2Ftemplate-package%2Findex.json)](https://dustuu.github.io/template-package)

In order to configure this badge for your repository instead of the original template repository, you will need to edit the two links within this badge as follows:
* `https://img.shields.io/vpm/v/<PACKAGE_NAME>?repository_url=https%3A%2F%2F<GITHUB_USERNAME>.github.io%2F<REPOSITORY_NAME>%2Findex.json`
* `https://<GITHUB_USERNAME>.github.io/<REPOSITORY_NAME>`

If you have optionally [set up automatic unit tests](#%EF%B8%8F-automating-unit-tests-optional), you can also add a badge that displays your [code coverage results](https://docs.unity3d.com/Packages/com.unity.testtools.codecoverage):

[![Code Coverage](https://dustuu.github.io/template-package/coverage/badge_linecoverage.svg)](https://dustuu.github.io/template-package/coverage)

In order to configure this badge for your repository instead of the original template repository, you will need to edit the two links within this badge as follows:
* `https://<GITHUB_USERNAME>.github.io/<REPOSITORY_NAME>/coverage/badge_linecoverage.svg`
* `https://<GITHUB_USERNAME>.github.io/<REPOSITORY_NAME>/coverage`

If you haven't set up automatic unit tests, you should remove this badge from your README file, as the source `.svg` image will not be generated.

For both badges, if you repository is owned by an organization instead of an individual user, use your organization's name instead of `GITHUB_USERNAME`.
It is recommended that you move these badges to the top of your README file, right underneath your repository title.

## 💻 Technical Stuff

You are welcome to make your own changes to the automation process to make it fit your needs, and you can create Pull Requests if you have some changes you think we should adopt. Here's some more info on the included automation:

### Build Release Action
[release.yml](/.github/workflows/release.yml)

This is a composite action combining a variety of existing GitHub Actions and some shell commands to create both a .zip of your Package and a .unitypackage. It creates a release which is named for the `version` in the `package.json` file found in your target Package, and publishes the zip, the unitypackage and the package.json file to this release.

### Build Repo Listing
[build-listing.yml](.github/workflows/build-listing.yml)

This is a composite action which builds a vpm-compatible [Repo Listing](https://vcc.docs.vrchat.com/vpm/repos) based on the releases you've created. In order to find all your releases and combine them into a listing, it checks out [another repository](https://github.com/vrchat-community/package-list-action) which has a [Nuke](https://nuke.build/) project which includes the VPM core lib to have access to its types and methods. This project will be expanded to include more functionality in the future - for now, the action just calls its `BuildRepoListing` target.
